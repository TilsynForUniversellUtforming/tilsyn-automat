﻿using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Difi.Sjalvdeklaration.Database.DbContext;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace Difi.Sjalvdeklaration.Database
{
    public class ValueListRepository : IValueListRepository
    {
        private string currentLang;
        private readonly ApplicationDbContext dbContext;

        public ValueListRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SetCurrentUser(Guid id)
        {

        }

        public void SetCurrentLang(string lang)
        {
            currentLang = lang;
        }

        public ApiResult<T> GetAllTypeOfMachine<T>() where T : List<ValueListTypeOfMachine>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.VlTypeOfMachineList.AsNoTracking().OrderBy(x => x.Text).FromCache().ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfTest<T>() where T : List<ValueListTypeOfTest>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.VlTypeOfTestList.AsNoTracking().OrderBy(x => x.Text).FromCache().ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfSupplierAndVersion<T>() where T : List<ValueListTypeOfSupplierAndVersion>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.VlTypeOfSupplierAndVersionList.AsNoTracking().OrderBy(x => x.Id).FromCache().ToList();

                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(currentLang == "nb-NO" ? item.Nb : item.Nn))
                    {
                        item.Text = currentLang == "nb-NO" ? item.Nb : item.Nn;
                    }
                }

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfStatus<T>() where T : List<ValueListTypeOfStatus>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.VlTypeOfStatus.AsNoTracking().OrderBy(x => x.Id).FromCache().ToList();

                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(currentLang == "nb-NO" ? item.Nb : item.Nn))
                    {
                        item.Text = currentLang == "nb-NO" ? item.Nb : item.Nn;
                    }

                    if (!string.IsNullOrEmpty(currentLang == "nb-NO" ? item.CompanyNb : item.CompanyNn))
                    {
                        item.TextCompany = currentLang == "nb-NO" ? item.CompanyNb : item.CompanyNn;
                    }
                }

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAllPurposeOfTest<T>() where T : List<ValueListPurposeOfTest>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.VlPurposeOfTest.AsNoTracking().OrderBy(x => x.Id).FromCache().ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }
    }
}