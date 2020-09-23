using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
	delegate void FindDelegate(int prime);
	class MyPrime
	{
		//이벤트는 클래스 안쪽에서 정의하게 되어있음
		//그리고 이벤트는 클래스 양쪽에서 정의되야함
		public event FindDelegate FindPrime; // 이벤트 정의 문법 : public event 델리게이트명 이벤트명; ==> public 이여야 외부에서 사용가능
		public void CheckPrime(int maxNum)
		{
			
			for (int i = 2; i < maxNum; i++) //1번for문
			{
				bool bPrime = true;  //반복문의 주의사항 : 변수를 반복문 밖에 뒀으면 반복문을 돌때마다 변수를 초기화 해줘야한다
				for (int p = 2; p < i; p++)//2번for문
				{
					if (i % p == 0)
					{
						bPrime = false;
						break;
					}
				}
				if(bPrime)
				{
					//Console.Write(i);
					FindPrime(i); //이벤트 발생 => 이벤트명 (전달할 값)
				}
				//break가 되어서 내려온 경우, 2번을 다돌고 내려온건지 구분이 가지 않을 때는 bool형 변수 사용해서 구분
			}
		}
	}
	class MyPrimeTest
	{
		static void Main()
		{
			Console.Write("솟수를 구하고 싶은 범위의 최대값을 입력해주세요 : ");
			int maxNum = int.Parse(Console.ReadLine());

			MyPrime pi = new MyPrime(); // 클래스의 인스턴스 만들고
			//델리게이트 등록(이벤트 핸들러 등록)
			//pi.FindPrime += new FindDelegate(PrintPrime);  //C#1.0문법
			pi.FindPrime += PrintPrime; //C#2.0 => new쓰기 귀찮으니 그냥 씀

			pi.CheckPrime(maxNum);
		}

		private static void PrintPrime(int prime) //이벤트 핸들러 => 이벤트가 일어나면 이 함수가 호출이 자동으로 될거임
		{
			Console.WriteLine("이벤트 발생 : " + prime);
		}
	}
}
