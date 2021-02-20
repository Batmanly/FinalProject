﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Cross Cutting Concerns >> uygulayi dikine kesenler
    //Log Cache Transaction Authorization

    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //Rules are here.
            RuleFor(p => p.ProductName).MinimumLength(2);//product name length minimum 2 krk olacak
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Urunler A hatfi ile baslamali");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");//a ile basliyormu baslamiyorumu ?
        }
    }
}
