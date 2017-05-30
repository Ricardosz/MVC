using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace ShoppingCart.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GenerateResultListFilterAttribute : System.Web.Http.Filters.FilterAttribute, IResultFilter
    {
        private readonly Type _sourceType;
        private readonly Type _destinationType;

        public GenerateResultListFilterAttribute(Type sourceType, Type destinationType)
        {
            _sourceType = sourceType;
            _destinationType = destinationType;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model;

            var resultListGenericType = typeof(ResultList<>).MakeGenericType(new Type[] { _destinationType });
            var srcGenericType = typeof(List<>).MakeGenericType(new Type[] { _sourceType });
            var destGenericType = typeof(List<>).MakeGenericType(new Type[] { _destinationType });

            AutoMapper.Mapper.CreateMap(_sourceType, _destinationType);
            var viewModel = AutoMapper.Mapper.Map(model, srcGenericType, destGenericType);

            var queryOptions = filterContext.Controller.ViewData.ContainsKey("QueryOptions") ?
                filterContext.Controller.ViewData["QueryOptions"] :
                new QueryOptions();

            var resultList = Activator.CreateInstance(resultListGenericType, viewModel, queryOptions);

            filterContext.Controller.ViewData.Model = resultList;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}