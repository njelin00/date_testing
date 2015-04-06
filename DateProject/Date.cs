using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateProject
{
    public class Date
    {
        int day, month, year;
        string[] month_name = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        int[] number_of_days_in_month = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public Date(int x_day, int x_month, int x_year)
        {
            CheckDateFormat(x_day, x_month, x_year);
            this.day = x_day;
            this.month = x_month;
            this.year = x_year;
        }

        public Date()
        {

        }

        private void CheckDateFormat(int day, int month, int year)
        {
            if (day <= 0 || month <= 0 || year <= 0)
            {
                throw new InvalidProgramException("Pogrešan unos. vrijednosti moraju biti pozitivne!");
            }
            if (month > 12)
            {
                throw new InvalidProgramException("Pogrešan unos! Broj mjeseci ne smije biti veći od 12!");
            }
            if (day > number_of_days_in_month[month - 1] || (isLeapYear(year) && month == 2 && day > number_of_days_in_month[month - 1] + 1))
            {
                throw new InvalidProgramException("Pogrešan unos! Unesen je broj dana veći nego što ga odabrani mjesec ima!");
            }
        }



        public string getMonthName(int month)
        {
            if (month < 0 ||month > 12)
            {
                throw new InvalidProgramException("Pogrešan Unos! Uneseni broj mjeseca ne postoji!");
            }
            return month_name[month - 1];
        }

        public string getMonthName()
        {
            return month_name[this.month - 1];
        }



        public int getNumberOfRemaingDaysInMonth(int day, int month, int year)
        {
            if (month == 2 && isLeapYear(year) && month <= 12)
            {
                return GetNumberOfDays(day, month) + 1;
            }
            return GetNumberOfDays(day, month);

        }

        public int getNumberOfRemaingDaysInMonth(int day, int month)
        {
            if (month == 2)
            {
                throw new InvalidProgramException("Veljača ovisno o godini ima drugačiji broj dana!");
            }
            return GetNumberOfDays(day, month);
        }




        private int GetNumberOfDays(int day, int month)
        {
            if (day > number_of_days_in_month[month - 1])
            {
                throw new InvalidProgramException("Unijeli ste veći broj dana nego što ih odabrani mjesec ima!");
            }
            return number_of_days_in_month[month - 1] - day;
        }

        public int getNumberOfRemaingDaysInMonth()
        {
            if (this.month == 2 && this.isLeapYear() && this.month <= 12)
            {
                return number_of_days_in_month[this.month - 1] - this.day + 1;
            }
            return number_of_days_in_month[this.month - 1] - this.day;
        }


        //racunamo je li godina prijestupna. ona koja je prijestupna je djeljiva sa 4 ako nije djeljiva sa 100
        //prijestupnim godinama dodajemo i one koje su djeljive sa 400
        public bool isLeapYear(int year)
        {
            return ((year%4 == 0 && year%10 != 0) || year%400 == 0);
        }

        public bool isLeapYear()
        {
            return ((this.year%4 == 0 && this.year%10 != 0) || this.year%400 == 0);
        }

    }
}
