
#pragma once
#include<iostream>
#include<string>
#include"mystr.h"
#include<Windows.h>
using namespace Mystr;
using namespace std;
class Date
{
public:
	int year;
	int month;
	int day;
	void convert(string str, char div)
	{
		mystr str1 = str;
		string * strp = str1.divstr(div);
		year = mystr::strToInt(strp[0]);
		month = mystr::strToInt(strp[1]);
		day = mystr::strToInt(strp[2]);
	}
	string convert(char div = ' ')
	{
		return mystr::ToStr(this->year) + div + mystr::ToStr(this->month) + div + mystr::ToStr(this->day);
	}
	Date(){
		year = month = day = 0;
	}
	Date(string str, char div)
	{
		convert(str, div);
	}
	Date operator=(const Date& d1)
	{
		this->year = d1.year;
		this->month = d1.month;
		this->day = d1.day;
		return *this;
	}
	void gettime()
	{
		SYSTEMTIME st;
		GetLocalTime(&st);
		this->year = st.wYear;
		this->month = st.wMonth;
		this->day = st.wDay;
	}
	Date& input()
	{
		char buffer[20];
		cin.getline(buffer, 20);
		this->convert(buffer, ' ');
		return *this;

	}
	inline bool operator>(Date date1)
	{
		if (this->year == date1.year)
		if (this->month == date1.month)
		if (this->day == date1.day)
			;
		else return((this->day > date1.day) ? 1 : 0);
		else return ((this->month > date1.month) ? 1 : 0);
		else return ((this->year > date1.year) ? 1 : 0);
		return 0;
	}
	inline bool operator== (Date date1)
	{
		return 	(this->year == date1.year&&this->month == date1.month&&this->day == date1.day) ? 1 : 0;
	}
	inline bool operator<(Date date1)
	{
		return (*this>date1 || (*this == date1)) ? 0 : 1;
	}
	inline bool operator<=(Date date1)
	{
		bool t = *this > date1;

		return (*this > date1) ? 0 : 1;
	}
	inline bool operator>=(Date date1)
	{
		bool t = (*this > date1 || *this == date1) ? 1 : 0;

		return (*this > date1 || *this == date1) ? 1 : 0;
	}
};