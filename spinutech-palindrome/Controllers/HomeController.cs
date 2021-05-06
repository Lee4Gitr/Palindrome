using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using spinutech_palindrome.Models;

namespace spinutech_palindrome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Palindrome(HomeViewModel model)
        {
            // Here I'm accepting the HomeViewModel that has the numerical value as a parameter of this Action on the 
            // Controller. I take that value and use the function "CreateViewModelForPalindrome" to determine if the
            // nmumber is a palindrome and return the necessary viewmodel for the Palindrome page view.
            var viewModel = CreateViewModelForPalindrome(model.Number);

            return View(viewModel);
        }

        private PalindromeViewModel CreateViewModelForPalindrome(long number)
        {
            // Searches from the left and right side simultaneously to ensure that each character matches. 
            var numString = number.ToString();
            var left = 0;
            var right = numString.Length - 1;

            bool isPalindrome = true;
            
            while (left <= right)
            {
                if (numString[left] != numString[right])
                {
                    isPalindrome = false;
                    break;
                }
                left++;
                right--;
            }

            return new PalindromeViewModel{isPalindrome = isPalindrome, num = long.Parse(numString)};
        }
    }
}