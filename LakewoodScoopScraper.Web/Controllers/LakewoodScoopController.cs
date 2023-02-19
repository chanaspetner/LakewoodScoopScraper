﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LakewoodScoopScraper.Scraper;

namespace LakewoodScoopScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LakewoodScoopController : ControllerBase
    {

        [HttpGet]
        [Route("scrape")]
        public List<LakewoodScoopPost> Scrape()
        {
            return LakewoodScoopeScrape.Scrape();
        }
    }
}
