﻿using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class CompanyFormModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        [BindProperty]
        public CompanyItem CompanyItemForm { get; set; }

        public CompanyFormModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    CompanyItemForm = await apiHttpClient.Get<CompanyItem>("/api/Company/Get/" + id);
                }
                else
                {
                    CompanyItemForm = new CompanyItem
                    {
                        ContactPersonList = new List<ContactPersonItem>
                        {
                            new ContactPersonItem()
                        }
                    };
                }
            }
            catch
            {
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                bool result;

                if (CompanyItemForm.Id != Guid.Empty)
                {
                    result = await apiHttpClient.Post<bool>("/api/Company/Update", CompanyItemForm);
                }
                else
                {
                    result = await apiHttpClient.Post<bool>("/api/Company/Add", CompanyItemForm);
                }

                if (result)
                {
                    return RedirectToPage("/Admin/CompanyList");
                }

                return Page();
            }
            catch
            {
                return Page();
            }
        }
    }
}