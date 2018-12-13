﻿using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Enum;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator,Saksbehandler")]
    public class CompanyListModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;
        private readonly IErrorHandler errorHandler;

        public IList<CompanyItem> CompanyList { get; private set; }

        public CompanyItem LocalizationItem { get; set; }

        private List<ValueListTypeOfMachine> valueListTypeOfMachine;
        private List<ValueListTypeOfTest> valueListTypeOfTest;
        private List<ValueListPurposeOfTest> valueListPurposeOfTest;

        [BindProperty]
        [Required(ErrorMessage = "You need to select a Excelfile")]
        [Display(Name = "Excel file")]
        public IFormFile ExcelFile { get; set; }

        public CompanyListModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task OnGetAsync()
        {
            try
            {
                var result = await apiHttpClient.Get<List<CompanyItem>>("/api/Company/GetAll");

                if (result.Succeeded)
                {
                    CompanyList = result.Data;
                }
                else
                {
                    await errorHandler.View(this, null, result.Exception);
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostExcelImportAsync()
        {
            try
            {
                if (!ExcelFile.FileName.EndsWith("xlsx"))
                {
                    return await errorHandler.View(this, OnGetAsync(), new Exception("Du måste ladda upp en excelfil!"));
                }

                var importTotaltCount = 0;
                var importOkCount = 0;
                var importFailCount = 0;
                var importExistCount = 0;

                var package = new ExcelPackage(ExcelFile.OpenReadStream());

                var dataTable = package.ToDataTable();

                valueListTypeOfMachine = (await apiHttpClient.Get<List<ValueListTypeOfMachine>>("/api/ValueList/GetAllTypeOfMachine")).Data;
                valueListTypeOfTest = (await apiHttpClient.Get<List<ValueListTypeOfTest>>("/api/ValueList/GetAllTypeOfTest")).Data;
                valueListPurposeOfTest = (await apiHttpClient.Get<List<ValueListPurposeOfTest>>("/api/ValueList/GetAllPurposeOfTest")).Data;

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    importTotaltCount++;

                    var result = await apiHttpClient.Post<ApiResult>("/api/Company/ExcelImport", CreateExcelItemRow(dataRow));

                    if (result.Succeeded)
                    {
                        importOkCount++;
                    }
                    else
                    {
                        if (result.Exception.InnerException != null && result.Exception.InnerException.Message == "exist")
                        {
                            importExistCount++;
                        }
                        else
                        {
                            importFailCount++;
                        }
                    }
                }

                if (importExistCount == 0 && importFailCount == 0)
                {
                    ViewData.Add("Done", $"Importen slutfördes. {importOkCount} av {importTotaltCount} importerades.");
                }
                else
                {
                    ViewData.Add("Done", $"Importen slutfördes. {importOkCount} av {importTotaltCount} importerades. (dubletter: {importExistCount}, övriga fel: {importFailCount})");
                }

                await OnGetAsync();

                return Page();
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(), exception);
            }
        }

        private ExcelItemRow CreateExcelItemRow(DataRow dataRow)
        {
            var companyId = Guid.NewGuid();
            var declarationItemId = Guid.NewGuid();

            var excelRow = new ExcelItemRow
            {
                CompanyItem = new CompanyItem
                {
                    Id = companyId,
                    Code = dataRow["Virksomhet - Pinkode"].ToString(),
                    ExternalId = dataRow["Virksomhet - Virksomhet ID (tilsynets datamodell)"].ToString(),
                    CorporateIdentityNumber = dataRow["Virksomhet - Organisasjonsnummer"].ToString(),
                    OwenerCorporateIdentityNumber = dataRow["Virksomhet - Organisasjonsnummer på hovedorgansasjonen"].ToString(),
                    Name = dataRow["Virksomhet - Virksomhet"].ToString(),

                    MailingAddressStreet = dataRow["Virksomhet - MailingAddress - Gatenavn og nummer"].ToString(),
                    MailingAddressZip = dataRow["Virksomhet - MailingAddress - Postnummer"].ToString(),
                    MailingAddressCity = dataRow["Virksomhet - MailingAddress - Sted"].ToString(),

                    LocationAddressStreet = dataRow["Virksomhet - LocationAddress - Gatenavn og nummer"].ToString(),
                    LocationAddressZip = dataRow["Virksomhet - LocationAddress - Postnummer"].ToString(),
                    LocationAddressCity = dataRow["Virksomhet - LocationAddress - Sted"].ToString(),

                    BusinessAddressStreet = dataRow["Virksomhet - BusinessAddress - Gatenavn og nummer"].ToString(),
                    BusinessAddressZip = dataRow["Virksomhet - BusinessAddress - Postnummer"].ToString(),
                    BusinessAddressCity = dataRow["Virksomhet - BusinessAddress - Sted"].ToString(),

                    IndustryGroupCode = dataRow["Virksomhet - IndustryGroup - Kode"].ToString(),
                    IndustryGroupDescription = dataRow["Virksomhet - IndustryGroup - Beskrivelse"].ToString(),
                    IndustryGroupAggregated = dataRow["Virksomhet - IndustryGroup - Aggregert"].ToString(),

                    InstitutionalSectorCode = dataRow["Virksomhet - InstitutionalSector - Kode"].ToString(),
                    InstitutionalSectorDescription = dataRow["Virksomhet - InstitutionalSector - Beskrivelse"].ToString(),

                },
                ContactPersonItem = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = dataRow["Kontaktperson - Navn"].ToString(),
                    Email = dataRow["Kontaktperson - E-postadresse"].ToString(),
                    PhoneCountryCode = dataRow["Kontaktperson - Landskode"].ToString(),
                    Phone = dataRow["Kontaktperson - Telefonnummer"].ToString(),
                    CompanyItemId = companyId,
                }
            };

            if (string.IsNullOrEmpty(excelRow.CompanyItem.Code))
            {
                var random = new Random(DateTime.Now.Millisecond);

                excelRow.CompanyItem.Code = random.Next(1000, 9999).ToString();
            }

            if (!string.IsNullOrEmpty(dataRow["Egenkontroll - Navn på egenkontroll"].ToString()))
            {
                excelRow.DeclarationItem = new DeclarationItem
                {
                    Id = declarationItemId,
                    CompanyItemId = companyId,
                    Name = dataRow["Egenkontroll - Navn på egenkontroll"].ToString(),
                    CaseNumber = dataRow["Egenkontroll - Saksnummer"].ToString(),
                    CreatedDate = DateTime.Now,
                    StatusId = (int) DeclarationStatus.Created,
                    UserItemId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value),
                    DeadlineDate = !string.IsNullOrEmpty(dataRow["Egenkontroll - Frist for innsending"].ToString()) ? Convert.ToDateTime(dataRow["Egenkontroll - Frist for innsending"].ToString()) : DateTime.Now.Date.AddDays(14).AddMinutes(-1),
                    DeclarationTestItem = new DeclarationTestItem
                    {
                        Id = declarationItemId,
                        TypeOfMachine = valueListTypeOfMachine.Single(x => x.Id == 1),
                        TypeOfTest = valueListTypeOfTest.Single(x => x.Id == 1),
                        PurposeOfTestId = !string.IsNullOrEmpty(dataRow["Egenkontroll - Formål med test"].ToString()) ? valueListPurposeOfTest.Single(x => x.Text == dataRow["Egenkontroll - Formål med test"].ToString()).Id : valueListPurposeOfTest.Single(x => x.Id == 2).Id
                    }
                };

                if (!string.IsNullOrEmpty(dataRow["Saksbehandler - Navn"].ToString()))
                {
                    excelRow.DeclarationItem.UserName = dataRow["Saksbehandler - Navn"].ToString();
                }
            }

            return excelRow;
        }
    }
}