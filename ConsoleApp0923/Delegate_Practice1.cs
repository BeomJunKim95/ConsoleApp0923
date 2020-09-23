using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
	class MyClass
	{
		private int number;

		public int Number
		{
			get { return number; }
			set { number = value; }
		}

		public void Plus(int val)
		{
			number += val;
		}
		public void Minus(int val)
		{
			number -= val;
		}
		public void Add(int num1, int num2)
		{
			Console.WriteLine(num1 + num2);
		}
		public static void PrintHello(int val) // 델리게이트가 스태틱도 부를수 있을까?
		{
			for(int i =0; i<val; i++)
			{
				Console.WriteLine("Hello");
			}
		}
	}

	delegate void Sample(int value); //델리게이트 선언 : void함수로 반환받고 파라미터는 int 하나인 메서드는 델리게이트로 호출하겠다는 뜻
									 // Add함수는 안됨 파라미터가 2개이기때문
	
	class Delegate_Practice1
	{
		

		static void Main()
		{
			MyClass c1 = new MyClass(); // num = 0

			//직접 인스턴스 메서드를 호출 ==> 직접 호출
			//c1.Plus(100);  // number = 100
			//c1.Minus(10);  // number = 90
			//c1.Add(10, 20);// 30출력
			//Console.WriteLine(c1.Number); // 90출력

			Sample s1 = new Sample(c1.Plus); // 메서드 앞에 ()하지말고 
			// 델리게이트는 연산이 가능하다
			s1 += new Sample(c1.Minus); //+=연산자로 인해 plus(100), Minus(100)
			s1(100); // 객체를 통해 원할때 호출 => plus(100), Minus(100)
			s1 -= new Sample(c1.Minus); // -=연산자로 인해 minus(100)가 빼져서 결과는 Plus(100) , ( C#1.0 문법 )
			s1(100); //Plus(100)
			Console.WriteLine(c1.Number); //100출력
			//여기까지 100
			//new하지 않아서 인스턴스를 계속 쓰기 깨문에 전의 값이 사라지지 않고 이어짐
			s1 = c1.Minus; // 100 - 200 = -100 ( C#2.0 문법 )
			s1 += c1.Plus; // -100 + 200 = 100
			s1 += c1.Plus; // 100 + 200 = 300
			s1(200);  // Minus(200), Plus(200), Plus(200)
			Console.WriteLine(c1.Number); //? : 300

			s1 += MyClass.PrintHello; // 등록할때는 파라미터 안써도 가능 => static도 가능!
									  // 델리게이트는 static이냐 아니냐는 상관 없고 반환타입과 파라미터만 맞으면 가능 => 시그니쳐가 맞아야함
			s1(5); // Minus(5), Plus(5), Plus(5)
			Console.WriteLine(c1.Number);

			
		}
	}
}
