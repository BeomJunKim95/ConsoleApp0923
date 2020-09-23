using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
	delegate void ClickDelegate();
	class MyButton
	{
		public event ClickDelegate Click; //이벤트 정의

		public void ButtonClick()
		{
			Click(); //이벤트 발생
		}
	}
	class ButtonTest
	{
		static void Main()
		{
			MyButton btn1 = new MyButton();
			btn1.Click += Button1_Click;

			MyButton btn2 = new MyButton();
			btn2.Click += Button2_Click;

			btn1.ButtonClick();
			btn2.ButtonClick();
		}

		private static void Button2_Click()
		{
			Console.WriteLine("btn2 버튼 클릭 발생");
		}

		private static void Button1_Click()
		{
			Console.WriteLine("btn1 버튼 클릭 발생");
		}
	}
}
