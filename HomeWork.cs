using System;

    public static class EvclidAlg
    {
    //this function realizes the Evclid algorithm for Gcd
        public static Int32 Gcd(Int32 a, Int32 b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }
    //this method implements the LCM algorithm
        public static Int32 Lcm(Int32 a, Int32 b)
        {
            return a / Gcd(a, b) * b;
        }
    }


    public class Fraction
    {
        Int32 numerator;
        Int32 denumerator;

        //Constructor for integer 
        public Fraction(Int32 num)
        {
            numerator = num;
            denumerator = 1;
        }
        //
        public Fraction(Int32 num,Int32 denum)
        {
            //if(denum == 0)
                //throw new DewideByZeroException;
            numerator = num;
            denumerator = denum;
            RefuceFraction();

        }
        //
        public Fraction(string str)
        {
            //none realized
        }

        //reduce fractions
        private  void RefuceFraction()
        {
             int nsd = EvclidAlg.Gcd(numerator,denumerator);
            if(nsd != 1)
            {
                numerator = numerator/nsd;
                denumerator = denumerator/nsd;
            }
        }

        public void Show()
        {  
            Int32 integer_part = 0;
            if(numerator>=denumerator)
            {
                integer_part=numerator/denumerator;
                Console.WriteLine(" {0} {1}/{2} ;",integer_part, numerator - integer_part*denumerator , denumerator);
            }
            else     
                Console.WriteLine(numerator+"/"+denumerator);
        }

        //overloadind add operator
        public static Fraction operator +(Fraction ob1,Fraction ob2)
        {
            Fraction sum = new Fraction(0);
            sum.denumerator = EvclidAlg.Lcm(ob1.denumerator,ob2.denumerator);
            sum.numerator = ob1.numerator*(sum.denumerator/ob1.denumerator) + ob2.numerator*(sum.denumerator/ob2.denumerator);
            sum.RefuceFraction();
            return sum;
        }

        //overloadind substraction(sub) operator
        public static Fraction operator -(Fraction ob1 , Fraction ob2)
        {
            Fraction sub = new Fraction(0);
            sub.denumerator = EvclidAlg.Lcm(ob1.denumerator,ob2.denumerator);
            sub.numerator = ob1.numerator*(sub.denumerator/ob1.denumerator) - ob2.numerator*(sub.denumerator/ob2.denumerator);
            sub.RefuceFraction();
            return sub;
        }

         //overloadind substraction(divine) operator
        public static Fraction operator /(Fraction ob1 , Fraction ob2)
        {
            Fraction div = new Fraction(0);
            int tmp;
            tmp = ob2.numerator;
            ob2.numerator=ob2.denumerator;
            ob2.denumerator=tmp;
            div.numerator = ob1.numerator*ob2.numerator;
            div.denumerator=ob1.denumerator*ob2.denumerator;
            div.RefuceFraction();
            return div;
        }

        //Multiply
        public static Fraction operator *(Fraction ob1 , Fraction ob2)
        {
            Fraction div = new Fraction(0);
            div.numerator = ob1.numerator*ob2.numerator;
            div.denumerator=ob1.denumerator*ob2.denumerator;
            div.RefuceFraction();
            return div;
        }

        //overriding ToString method
        public override string ToString()
        {   
            Int32 integer_part = 0;
            if(numerator>=denumerator)
            {
                integer_part=numerator/denumerator;
               return string.Format(" {0} {1}/{2} ;",integer_part, numerator - integer_part*denumerator , denumerator);
            }
            else 
                return string.Format("{0}/{1}",numerator,denumerator);
        }

        //overriding Equals method
        public override bool Equals(object ob)
        {   
            Fraction tmp= (Fraction)ob;
            tmp.RefuceFraction();
            this.RefuceFraction();
            return (tmp.denumerator==this.denumerator&&tmp.numerator==this.numerator)? true:false;
        }

      

        public override int GetHashCode() 
        {
            return Int32.Parse(string.Format("{0}{1}",numerator,denumerator));
        }
    }


//
public class Program
{
    public static void Main()
    {
        Fraction fr1 = new Fraction(5,20);
        
        Fraction fr2 = new Fraction(2,3);
        System.Console.WriteLine("{0}*{1}+{2}/{3}",fr1,fr2,fr2,fr1);
        Fraction sum = fr1*fr2 + fr2/fr1;
        Console.WriteLine( sum.ToString());

        if(new Fraction(1,4).Equals(new Fraction(2,4)))
            System.Console.WriteLine("1/4==2/4");
        Console.ReadKey();
    }
}