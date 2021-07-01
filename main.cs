using System;

class MainClass {
  public static void Main (string[] args) {
    double hw, tw, CA;
    string valI;
    Console.WriteLine ("\nWelcome \n\nBulb Section");

    Console.WriteLine ("Enter Web height:");
    valI= Console.ReadLine();
    hw= Convert.ToDouble(valI);

    Console.WriteLine ("Enter Web thickness:");
    valI= Console.ReadLine();
    tw= Convert.ToDouble(valI);

    double[] Dim = new double[4];
    Dim= getangle(hw,tw);

    Console.WriteLine("Equivalent Angle dimensions for hw, tw, bf, tf:");
    for(int i=0;i<4;i++)
    {
      Console.WriteLine(Math.Round(Dim[i],2));
    }

    Console.WriteLine("Cross sectional area of the angle section:");
    CA= (Dim[0]*Dim[1] + Dim[2]*Dim[3]);
    Console.WriteLine(Math.Round(CA,2));

    Console.WriteLine("Area Moment of Inertia of the angle section:");
    double[] MI = MICal(Dim[0], Dim[1], Dim[2], Dim[3]);
    Console.WriteLine(MI[0]);
    Console.WriteLine("\n\nThank you");

  }

  public static double[] getangle(double hw, double tw)
  {
    double[] Adim= new double[4];
    double alpha;

    if(hw<=120)
    alpha=1.1+ Math.Pow(120-hw,2)/3000;

    else
    alpha=1.0;

    double Ahw,Atw,Abf,Atf;

    Ahw=hw-hw/9.2 + 2;
    Atw =tw;
    Abf=alpha * (tw+hw/6.7 - 2);
    Atf= hw/9.2 - 2;

    Adim[0] = Ahw;
    Adim[1] = Atw;
    Adim[2] = Abf;
    Adim[3] = Atf;

    return Adim;
    
  }

  public static double[] MICal(double hw, double tw, double bf, double tf)
        {
            double A1, A2,Y1,Y2, Y_bar, Ixx1, Ixx2, Ixx;
            double[] moments = new double[1];

            A1 = bf * tf;
            A2 = hw * tw;
            Y1 = hw + (tf / 2);
            Y2 = hw / 2;

            Y_bar = (((A1 * Y1) + (A2 * Y2)) /(A1+A2));


            Ixx1 = ((tw * Math.Pow(hw,3))/12) + ((Y_bar - (hw / 2)) * (Y_bar - (hw / 2)) * (hw * tw));
            Ixx2 =  ((bf * Math.Pow(tf, 3)) /12) + ((hw + (tf / 2) - Y_bar) * (hw + (tf / 2) - Y_bar) * (bf * tf));

            Ixx = Ixx1 + Ixx2;

            moments[0] = Math.Round(Ixx/10000,2);

            return moments;
        }
}