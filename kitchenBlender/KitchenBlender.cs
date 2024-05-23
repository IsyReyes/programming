using System;
using System.Data;

public class KitchenBlender{


//can't operante empty
//speed can only go up 1 unit at a time


    public int speed = 0;
    public bool filled = false;

    public void CheckInvariant(){

        if (speed < 0 || speed > 10){
            Console.WriteLine("This is an invalid entry, the button you are trying to press does not exist.");
        }
    }

    public void Fill(){
        Console.WriteLine("Enter 1 to fill, 2 to exit.");
        int input = Convert.ToInt32(Console.ReadLine());

        switch(input){
            case 1:
                Console.WriteLine("Blender filled");
                filled = true;
                Console.WriteLine("Blender filled, please select your speed from 1 to 10.");
                SetSpeed(Convert.ToInt32(Console.ReadLine()));
                break;
            case 2:
                Console.WriteLine("Process terminated");
                break;
            default:
                Console.WriteLine("Invalid input. Process terminated.");
                break;
        }
    }

    public void SetSpeed(int newSpeed){

        if(!filled){
            Console.WriteLine("Blender cannot operate empty.");
            return;
        }

        if (newSpeed < 0 || newSpeed > 10)
        {
            throw new ArgumentException("Speed must be between 0 and 10.");
        }

        speed = newSpeed;
        CheckInvariant();
        Console.WriteLine($"Speed set to {speed}");
        RunBlender();

    }

    public void RunBlender()
    {
        CheckInvariant();

        if (!filled)
        {
            Console.WriteLine("Blender cannot operate empty.");
            return;
        }

        switch (speed)
        {
            case 0:
                Console.WriteLine("The blender is off");
                break;
            default:
                Console.WriteLine($"Speed selected is {speed}");
                AdjustSpeed();
                break;
        }
    }

    public void AdjustSpeed()
    {
        Console.WriteLine($"Current speed is {speed}. Press 0 to turn off or adjacent button to increase or decrease speed.");
        int newInput = Convert.ToInt32(Console.ReadLine());

        if (newInput == 0)
        {
            speed = 0;
            Console.WriteLine("You turned off the blender.");
        }
        else if (newInput == speed)
        {
            Console.WriteLine("You pressed the same button, nothing happens.");
            AdjustSpeed();
        }
        else if (newInput == speed + 1 || newInput == speed - 1)
        {
            SetSpeed(newInput);
        }
        else
        {
            Console.WriteLine("Invalid input. Speed can only be adjusted by 1 unit at a time.");
            AdjustSpeed();
        }
    }

}