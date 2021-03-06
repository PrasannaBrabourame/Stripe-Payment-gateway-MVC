﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MCVAPP.Models;
using Stripe;

namespace MCVAPP.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Charge(string stripeEmail, string stripeToken)
		{
			var customers = new StripeCustomerService();
			var charges = new StripeChargeService();

			var customer = customers.Create(new StripeCustomerCreateOptions
			{
				Email = stripeEmail,
				SourceToken = stripeToken
			});


			var charge = charges.Create(new StripeChargeCreateOptions
			{
				Amount = 500,
				Description = "Sample Charge",
				Currency = "usd",
				CustomerId = customer.Id
			});

			return View();
		}

	}
}
