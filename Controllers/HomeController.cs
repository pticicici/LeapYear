using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeapYear.Models;

namespace LeapYear.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new GetDateViewModel());
        }

        [HttpPost]
        public IActionResult Index(int month, int year)
        {
            string result="The results is the following: ";
            if(getDayInMonth(month,year)!=-1)
            {
                if(isLeapYear(year))
                {
                    result+= "Year "+ year+ " is a leap year";
                }
                else
                {
                    result+= "Year "+ year+ " is not a leap year";
                }
                if(getDayInMonth(month,year)!=-1)
                {
                    result+=" and "+month+". month has "+getDayInMonth(month,year)+" days in it.";
                }
            }
            else
            {
                result+=" -1: There is an error in inputed data, check if the month is in 1-12 range and if the year is in 1-9999 range.";
            }
            GetDateViewModel mod = new GetDateViewModel();
            mod.month=month;
            mod.year=year;
            mod.result=result;

            return View(mod);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool isLeapYear(int year)
        {
           double checkDivision = year%4;
           double checkDivision2 = year%100;
           double checkDivision3 = year%400;
        
            if(year>=1 & year<=9999){    
                if(checkDivision==0)
                {
                    if(checkDivision2==0)
                    {
                        if(checkDivision3==0)
                        {
                            return true;
                        }
                        return false;
                    }
                    return true;
                }
            }
            else{}
            return false;
        }

        public int getDayInMonth(int month, int year)
        {
            if(month<1 | month>12)
            {}
            else if(year<1 | year>9999)
            {}
            else
            {
                if(month==2)
                {
                   if(isLeapYear(year))
                   {
                       return 29;
                   }
                   else{
                       return 28;
                   }
                }
                else if(month==1 | month==3 | month==5 | month==7 | month==8 | month==10 | month==12)
                {
                    return 31;
                }
                else
                {
                    return 30;
                } 
            }
            return -1;
        }
    }
}
