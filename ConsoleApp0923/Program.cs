using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
	class SingerNameComparer : IComparer // sort에 직접줄때는 Comparer를 써야함
                                     // 다른클래스로 비교하는걸 따로 만들 때에는 IComparer
    {
        public int Compare(object x, object y) // Compare는 인자가 두개
		{
            //나이가 크면 1, 나이가 작으면 -1, 나이가 같으면 0
            Singer first = x as Singer;
            Singer second = y as Singer;

            if (first.Name.CompareTo(second.Name)==1)
                return 1; // 오름차순
                //return -1;  // 내림차순 1이면 바꾸고 -1이면 안바꾸고
            else if (first.Name.CompareTo(second.Name) == -1)
                return -1; //오름차순
                //return 1;  //내림차순
            else
                return 0;
        }
	}
	class Singer : IComparable  // 비교할때 기준이 필요할때 쓰는 IComparable 인터페이스
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AlbumCnt { get; set; }

        public Singer(string name, int age, int albumCnt)
        {
            Name = name;
            Age = age;
            AlbumCnt = albumCnt;
        }

        public override string ToString()
        {
            return $"{Name} - {Age}세 - {AlbumCnt}집 앨범";
        }

		public int CompareTo(object obj)  //IComparable 인ㅌ페이스 구현 하면 나오는 CompareTo 메서드
		{
			#region 나이 기준
			//나이가 크면 1, 나이가 작으면 -1, 나이가 같으면 0
			Singer sing = obj as Singer;

            if (sing == null) 
                return 0;
            if (this.Age > sing.Age)
                //return 1; // 오름차순
                return -1;  // 내림차순 1이면 바꾸고 -1이면 안바꾸고
            else if (this.Age < this.Age)
                //return -1; //오름차순
                return 1;  //내림차순
            else
                return 0;
			#endregion
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
            Singer[] singers = new Singer[5] {
                    new Singer("아이유", 28, 8),
                    new Singer("자우림", 40, 5),
                    new Singer("거미", 35, 5),
                    new Singer("이승철", 50, 15),
                    new Singer("태진아", 65, 5)
            };

            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }

            Console.WriteLine("======================================");
            Console.WriteLine();

            Array.Sort(singers);
            //Array.Reverse(singers); // 역순으로 정렬할때 하지만 좋은방법은 아님

            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }

            Console.WriteLine("======================================");
            Console.WriteLine();

            SingerNameComparer nameComparer = new SingerNameComparer();
            Array.Sort(singers,nameComparer); // 이름으로 정렬
            
            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }
        }
    }
}
