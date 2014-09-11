﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using WebAPIODataKeys.Models;

namespace WebApiODataKeys.Controllers
{
	[ODataRoutePrefix("Stadium")]
	public class StadiumController : ODataController
	{
		[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
		[HttpGet]
		[ODataRoute]
		public IHttpActionResult Get()
		{
			return Ok(new List<Stadium> { new Stadium { Capacity = 2300, Country = "Switzerland", Name = "Times Stadium", Owner = "FC Zug" } });
		}

		// GET odata/stadium?name=fds&country=Switzerland
		//[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
		//[HttpGet]
		//public IHttpActionResult Get(string name, string country)
		//{
		//	return Ok(new Stadium { Capacity = 2300, Country = "Switzerland", Name = "Times Stadium", Owner = "FC Zug" });
		//}

		// http://localhost:60096/odata/Stadium%28Name=%27rrr%27,%20Country=%273333%27%29
		[ODataRoute("(Name={name}, Country={country})")]
		[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
		[HttpGet]
		public IHttpActionResult Get([FromODataUri] string name, [FromODataUri] string country)
		{
			return Ok(new Stadium { Capacity = 2300, Country = "Switzerland", Name = "Times Stadium", Owner = "FC Zug" });
		}

		// http://localhost:60096/odata/Stadium/D.GetStadiumTest(test='ddd', land='ssss')
		[ODataRoute("D.GetStadiumTest(test={test}, name={name})")]
		[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
		[HttpGet]
		public IHttpActionResult GetStadiumTest([FromODataUri] string test, [FromODataUri] string name)
		{
			return Ok(new List<Stadium> { new Stadium { Capacity = 2300, Country = name, Name = test, Owner = "FC Zug" } });
		}

		[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute("D.GetStadiumsWithFunction()")]
		[HttpGet]
		public IHttpActionResult GetStadiumsWithFunction()
		{
			return Ok( new Stadium { Capacity = 2300, Country = "Switzerland", Name = "Times Stadium", Owner = "FC Zug" } );
		}

		//[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
		//[ODataRoute("(Name={name}, Country={country})/D.GetExtraDetailsWithFunction()")]
		//[HttpGet]
		//public IHttpActionResult GetExtraDetailsWithFunction(string name, string country)
		//{
		//	return Ok("Some extra details in a string");
		//}

	}
}
