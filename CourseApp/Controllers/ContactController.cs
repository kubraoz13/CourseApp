﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseApp.Data.Abstract;
using CourseApp.Models;

namespace CourseApp.Controllers
{
    public class ContactController : Controller
    {
        private IGenericRepository<Contact> _repository;
        public ContactController(IGenericRepository<Contact> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }
    }
}