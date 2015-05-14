using System;

//Problem 12.** Falling Rocks
//• Implement the "Falling Rocks" game in the text console. ◦ A small dwarf stays
//at the bottom of the screen and can move left and right (by the arrows keys).
//◦ A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
//◦ Rocks are the symbols  ^, @, *, &, +, %, $, #, !, ., ;, -  distributed with appropriate density. The dwarf is  (O) .
//• Ensure a constant game speed by  Thread.Sleep(150) .
//• Implement collision detection and scoring system.
//More C# console games:
//http://github.com/NikolayIT/CSharpConsoleGames

class Falling_Rocks
{
    static void Main()
    {
        //I did this entirely on my own I haven`t read any similar problem solutions
        //so this is my original approach without any influences from examples
        //I have some computer graphics and animation background (not development) from user standpoint
        //I`ll use the console as image screen with a technic called scanline rendering.
        //I`ll assume my every frame resolution is the size of the console width and height. Imagine one character as pixel.
        //then I`ll use a cycle to redraw every frame (console screen) starting from the first line (topmost)
        //I`ll control the framerate (refreshment of the console) using Thread.Sleep() method
        Console.SetBufferSize(80, 25);  
        //first we set the console "resolution"
        //I keep it minimum height for faster redraw of the scanlines. 25 is the lowest possible
        string[] frameBuffer = new string[25];  //the total lines of the screen resolution are 25, we`ll use array with 25 strings
        //with 80 characters in each string to render the entire screen frame. You can think of this as a frame buffer
        //When the new frame is generated we draw it on the screen using simple for cycle. This way we achieve faster and flicker-free framerate
        string currentLine = "";
        int move = 0;
        Random rInd = new Random(); //.NET functionality to generate random number
        int r = rInd.Next(1, 100);  //generate next random integer in range 1 to 100 and asign to r

        for (int i = 0; i < 25; i++)    //define the starting frame with empty spaces, blank console screen
        {
            frameBuffer[i] = new string(' ', 79);
        }

    start:  //this is the point from which the render engine begins
        do
        {
            frameBuffer[24] = new string(' ', 36 + move) + "(0)" + new string(' ', 40 - move);     //draws the last line of the frame with the rocket (0) in center

            System.Threading.Thread.Sleep(150); //game speed control

            Console.Clear();
            //the screen clear method helps with the problem when the buffer is not rendered completely to screen
            //and a key is pressed to move the rocket, which starts the next rendering on top of the unfinished previous.
            //This ultimately leads to screen flickering.

            for (int j = 0; j < 25; j++)    //new frame render cycle immediately after clearing the screen
            {
                Console.WriteLine(frameBuffer[j]);     //we keep it very simple for smooth live animation, just printing 25 lines from the frame buffer array
            }

            currentLine = frameBuffer[23];     //collision detection cycle. Will exit the entire program with a goto statement if collision
            if (currentLine[36 + move] != ' ' || currentLine[37 + move] != ' ' || currentLine[38 + move] != ' ')
            {
                goto end;  //goes to the ending code block if collision is detected
            }

            //next cycle is redrawing the next frame. Each line (except first and last) is copied from the previous line, since we want the rocks to fall down
            for (int i = 0; i < 23; i++)    
            {
                frameBuffer[23 - i] = frameBuffer[23 - i - 1];  //the new image is written to the frame buffer, one line per cycle
            }

            //Next we randomise the next frame`s first line.
            
            frameBuffer[0] = "";    //first clear the first frame line

            for (int i = 0; i < 79; i += 1) //cycle to randomise the next frame`s first line
            {
                if (r % 13 == 0 && r % 7 == 0)
                {
                    frameBuffer[0] += new string('*', 1);
                }
                else
                {
                    frameBuffer[0] += new string(' ', 1);
                }
                r = rInd.Next(1, 100);
            }          
            //with randomisation of the first line of every frame we get new patterns of falling rocks every time there`s a new frame generated
            //in the frame buffer.
        }
        while (!Console.KeyAvailable);  //continue redrawing screen, generating new falling rocks and look for collison until a key is pressed

        if (Console.ReadKey().Key == ConsoleKey.LeftArrow)  // if left arrow key is detected
        {
            move -= (move > -36) ? 1 : 0;  //increment move, which will move the rocket 1 char to the left of starting position unless screen end is reached
            goto start;   //return back to the screen rendering algorithm and start rendering the new frame
        }
        else
        {
            move += (move < 40) ? 1 : 0;  //any other key is pressed moves the rocket 1 char to the right of starting position unless screen end is reached
            //I didn`t use right arrow because the second Console.ReadKey().Key check stopped the program and waited for input, couldn`t solve this problem, but this works, too.
            //I COULD USE SOME ADVICE HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            goto start;
        }

    end:
        Console.Write("{0,50}", "BAAAAAAAAAAM!!!!!!!!!!");
        Console.Read();

        //I presume that by using methods I can bypass the goto statements, but i`m still not familiar with methods,
        //so please be merciful :). Even if goto is not good practice, there are some situations where it actually helps keep things more tidy and readable.
    }
}