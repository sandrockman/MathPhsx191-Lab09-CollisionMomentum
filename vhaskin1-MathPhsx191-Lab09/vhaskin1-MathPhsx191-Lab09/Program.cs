using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * @author Victor Haskins
 * class program will calculate the reflection vector of an object off of a
 * plane determined by two other vectors and the coefficient of restitution
 * 
 * Program will also be able to model collision of two objects in 1D which will
 * take inputs the initial velocities and masses of two objects as well as the
 * coefficient of restitution.
 */
class Program
{
    static void Main(string[] args)
    {
        //AngleOfReflection();
        Model1DCollision();
    }

    static void AngleOfReflection()
    {
        double getX, getY, getZ, epsilon;
        getX = getY = getZ = epsilon = 0;
        Vector3D vector1 = new Vector3D();
        Vector3D vector2 = new Vector3D();

        Vector3D objectVector = new Vector3D();

        Console.Write("Please Enter Coefficient of restitution: ");
        epsilon = Convert.ToDouble(Console.ReadLine());

        Console.Write("Please Enter X for vector 1: ");
        getX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Y for vector 1: ");
        getY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Z for vector 1: ");
        getZ = Convert.ToDouble(Console.ReadLine());

        vector1.SetRectGivenRect(getX, getY, getZ);

        getX = getY = getZ = 0;
        Console.Write("Please Enter X for vector 2: ");
        getX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Y for vector 2: ");
        getY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Z for vector 2: ");
        getZ = Convert.ToDouble(Console.ReadLine());

        vector2.SetRectGivenRect(getX, getY, getZ);

        getX = getY = getZ = 0;
        Console.Write("Please Enter X for object vector: ");
        getX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Y for object vector: ");
        getY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Z for object vector: ");
        getZ = Convert.ToDouble(Console.ReadLine());

        objectVector.SetRectGivenRect(getX, getY, getZ);

        Vector3D normalVector = vector1 / vector2;
        Vector3D normalizedNormal = !normalVector;

        Vector3D finalVelocity = objectVector 
            -( ((1 + epsilon) * (normalizedNormal * objectVector) ) 
            & normalizedNormal );

        Console.WriteLine("Reflected vector is < " + finalVelocity.XValue +
            ", " + finalVelocity.YValue + ", " + finalVelocity.ZValue + ">.");
    }

    static void Model1DCollision()
    {
        double initV1, initV2;
        double mass1, mass2;
        double finalV1, finalV2;
        double epsilon;
        initV1 = initV2 = mass1 = mass2 = finalV1 = finalV2 = epsilon = 0;

        Console.Write("Please Enter initial velocity of object 1: ");
        initV1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter initial velocity of object 2: ");
        initV2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("\nPlease Enter mass of object 1: ");
        mass1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter mass of object 2: ");
        mass2 = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("\nPlease Enter coefficient of restitution: ");
        epsilon = Convert.ToDouble(Console.ReadLine());

        finalV1 = (((mass1 - (epsilon * mass2)) * initV1) +
                   ((1 + epsilon) * mass2 * initV2)) / (mass1 + mass2);
        //*
        finalV2 = (((mass2 - (epsilon * mass1)) * initV2) +
                   ((1 + epsilon) * mass1 * initV1)) / (mass1 + mass2);
        //*/
        //finalV2 = finalV1 + epsilon * (initV1 - initV2);

        Console.WriteLine("\nFinal velocity of object 1 is : " + finalV1);
        Console.WriteLine("Final velocity of object 2 is : " + finalV2);

        
    }
}