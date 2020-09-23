using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
	class CPonit3D
	{
		public int x;
		public int y;
		public int z;

		public CPonit3D()
		{

		}
		public CPonit3D(int x, int y, int z) //구조체는 기본생성자를 명시적으로 생성 불가
											//모든 멤버의 인자를 다 명시해줘야 생성자 사용가능
		{
			this.x = x;
			this.y = y;
			this.z = z; //하나라도 쓰지 않으면 컴파일 불가
		}
		public override string ToString()
		{
			return $"(x, y, z) = ({x}, {y}, {z})";
		}
	}
	class MyClass1
	{
		static void Main()
		{
			//CPonit3D point; //구조체와의 차이 클래스는 반드시 new해야함
			//point.x = 20;
			//point.y = 10;
			//point.z = 5;
			//Console.WriteLine(point.ToString());

			CPonit3D point1 = new CPonit3D(); //구조체와는 다르게 기본생성자가 없기 때문에 컴파일 오류 

			point1.x = 70;
			point1.y = 50;
			point1.z = 40;
			Console.WriteLine(point1.ToString());

			CPonit3D point2 = new CPonit3D(90, 30, 10); // 각각의 멤버변수의 값을 주기 귀찮아 생성자를 쓰는것
													  // 이게 구조체에서 new를 쓰는 이유임
			Console.WriteLine(point2.ToString());

			CPonit3D point3 = point2;
			point3.z = 900;
			Console.WriteLine(point2.ToString()); //(90, 30, 10) => (90, 30, 900)
												  // 클래스는 참조타입이라 원본변수의 값도 같이 바뀌어 point2.z도 900으로 바뀜
			Console.WriteLine(point3.ToString()); //(90, 30 ,900)
		}
	}
}
