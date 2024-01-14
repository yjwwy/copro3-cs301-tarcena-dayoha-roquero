using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CharacterSimulator
{
    public abstract class Character
    {
        public abstract void DisplayCharacterInformation();
    }

    public interface Character2
    {
        public void CreateCharacter();
        public void DisplayCharacter();
        public void RemoveCharacter();
    }

    public struct CharacterInformation
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public bool Married { get; set; }
        public CharacterAppearance Appearance { get; set; }
        public CharacterStats Stats { get; set; }
    }
    public class CharacterAppearance
    {
        public string Faceshape { get; set; }
        public string Skincolor { get; set; }
        public string Hairstyle { get; set; }
        public string Haircolor { get; set; }
        public string Eyebrows { get; set; }
        public string Eyeshape { get; set; }
        public string Eyecolor { get; set; }
        public string Liptypes { get; set; }
        public string Lipcolor { get; set; }
        public string Bodytype { get; set; }
        public string Top { get; set; }
        public string Topcolor { get; set; }
        public string Bottom { get; set; }
        public string Bottomcolor { get; set; }
        public string Footwear { get; set; }
        public string Accessories { get; set; }
        public string Occupation { get; set; }
    }
    public class CharacterStats
    {
        public int Timid { get; set; }
        public int Expressive { get; set; }
        public int Cheerful { get; set; }
        public int Calm { get; set; }
        public int Aggressive { get; set; }
    }
    public class CharacterSimulator : Character, Character2
    {
        public CharacterInformation Features { get; set; }
        public CharacterSimulator()
        {
        }

        public CharacterSimulator(string name, string age, string gender, bool married, CharacterAppearance appearance, CharacterStats stats)
        {
            this.Features = new CharacterInformation
            {
                Name = name,
                Age = age,
                Gender = gender,
                Married = married,
                Appearance = appearance,
                Stats = stats
            };
        }
        public void CharacterCreation()
        {
            SqlConnection SqlConnection;
            string DatabaseConnection = @" Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = C:\USERS\ACER\SOURCE\REPOS\COMPROGFINALTP\COMPROGFINALTP\COMPROGDATABASE.MDF; Integrated Security = True; ";

            try
            {
                SqlConnection = new SqlConnection(DatabaseConnection);
                SqlConnection.Open();

                CharacterSimulator information = new CharacterSimulator();
                string name;
                while (true)
                {
                    Console.Write("\nName: ");
                    name = Console.ReadLine();

                    if (name == "")
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                    else if (Regex.IsMatch(name, @"[^a-zA-Z0-9/<>*/+]"))
                    {
                        Console.WriteLine("Empty name, Please input a name");

                    }
                    else
                    {
                        string check = "SELECT COUNT(*) FROM dbo.charactertable WHERE user_name = @Name";
                        using (SqlCommand checkName = new SqlCommand(check, SqlConnection))
                        {
                            checkName.Parameters.AddWithValue("@Name", name);

                            int existingName = (int)checkName.ExecuteScalar();

                            if (existingName > 0)
                            {
                                Console.WriteLine("!! This name already exists. Please choose a different name !!");
                                return;
                            }
                        }
                        break;
                    }
                }

                int age;
                string ageValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nAge Groups: \n1.) Kid\n2.) Teenager\n3.) Adult\n4.) Senior");
                        Console.Write("Choice: ");
                        age = Convert.ToInt32(Console.ReadLine());
                        if (age == 1)
                        {
                            ageValue = "Kid";
                            break;
                        }
                        else if (age == 2)
                        {
                            ageValue = "Teenager";
                            break;
                        }
                        else if (age == 3)
                        {
                            ageValue = "Adult";
                            break;
                        }
                        else if (age == 4)
                        {
                            ageValue = "Senior";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try again !!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int gender;
                string genderValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nGender: \n1.) Male\n2.) Female\n3.) Non-binary");
                        Console.Write("Choice: ");
                        gender = Convert.ToInt32(Console.ReadLine());
                        if (gender == 1)
                        {
                            genderValue = "Male";
                            break;
                        }
                        else if (gender == 2)
                        {
                            genderValue = "Female";
                            break;
                        }
                        else if (gender == 3)
                        {
                            genderValue = "Non-binary";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int marry;
                bool marryValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nAre you married?");
                        Console.WriteLine("1.) Yes\n2.) No ");
                        Console.Write("Choice: ");
                        marry = Convert.ToInt32(Console.ReadLine());
                        if (marry == 1)
                        {
                            marryValue = true;
                            break;
                        }
                        else if (marry == 2)
                        {
                            marryValue = false;
                            break;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid String Input, Try Again !!");
                    }
                }
                Console.WriteLine("\n\n[Character Features]\n");
                int faceshape;
                string faceshapeValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("FACE SHAPE: \n1.) Oval\n2.) Square\n3.) Round\n4.) Diamond\n5.) Heart");
                        Console.Write("Choice: ");
                        faceshape = Convert.ToInt32(Console.ReadLine());
                        if (faceshape == 1)
                        {
                            faceshapeValue = "Oval";
                            break;
                        }
                        else if (faceshape == 2)
                        {
                            faceshapeValue = "Square";
                            break;
                        }
                        else if (faceshape == 3)
                        {
                            faceshapeValue = "Round";
                            break;
                        }
                        else if (faceshape == 4)
                        {
                            faceshapeValue = "Diamond";
                            break;
                        }
                        else if (faceshape == 5)
                        {
                            faceshapeValue = "Heart";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int skincolor;
                string skincolorValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nSKIN COLOR: \n1.) Pale\n2.) Tanned\n3.) Brown\n4.) Dark Brown\n5.) Black");
                        Console.Write("Choice: ");
                        skincolor = Convert.ToInt32(Console.ReadLine());
                        if (skincolor == 1)
                        {
                            skincolorValue = "Pale";
                            break;
                        }
                        else if (skincolor == 2)
                        {
                            skincolorValue = "Tanned";
                            break;
                        }
                        else if (skincolor == 3)
                        {
                            skincolorValue = "Brown";
                            break;
                        }
                        else if (skincolor == 4)
                        {
                            skincolorValue = "Dark Brown";
                            break;
                        }
                        else if (skincolor == 5)
                        {
                            skincolorValue = "Black";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int hairstyle;
                string hairstyleValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nHAIRSTYLE: \nMEN\n1.) Fade\n2.) Buzz cut\n3.) Braids\n4.) Mohawk\n5.) Afro\nWOMEN  \n6.) Pixie cut\n7.) Bob\n8.) Bun\n9.) Curly hair\n10.) Straight hair");
                        Console.Write("Choice: ");
                        hairstyle = Convert.ToInt32(Console.ReadLine());
                        if (hairstyle == 1)
                        {
                            hairstyleValue = "Oval";
                            break;
                        }
                        else if (hairstyle == 2)
                        {
                            hairstyleValue = "Square";
                            break;
                        }
                        else if (hairstyle == 3)
                        {
                            hairstyleValue = "Round";
                            break;
                        }
                        else if (hairstyle == 4)
                        {
                            hairstyleValue = "Diamond";
                            break;
                        }
                        else if (hairstyle == 5)
                        {
                            hairstyleValue = "Heart";
                            break;
                        }
                        else if (hairstyle == 6)
                        {
                            hairstyleValue = "Oval";
                            break;
                        }
                        else if (hairstyle == 7)
                        {
                            hairstyleValue = "Square";
                            break;
                        }
                        else if (hairstyle == 8)
                        {
                            hairstyleValue = "Round";
                            break;
                        }
                        else if (hairstyle == 9)
                        {
                            hairstyleValue = "Diamond";
                            break;
                        }
                        else if (hairstyle == 10)
                        {
                            hairstyleValue = "Heart";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int haircolor;
                string haircolorValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nHAIR COLOR: \n1.) Black\n2.) Brown\n3.) White\n4.) Red\n5.) Yellow");
                        Console.Write("Choice: ");
                        haircolor = Convert.ToInt32(Console.ReadLine());
                        if (haircolor == 1)
                        {
                            haircolorValue = "Black";
                            break;
                        }
                        else if (haircolor == 2)
                        {
                            haircolorValue = "Brown";
                            break;
                        }
                        else if (haircolor == 3)
                        {
                            haircolorValue = "White";
                            break;
                        }
                        else if (haircolor == 4)
                        {
                            haircolorValue = "Red";
                            break;
                        }
                        else if (haircolor == 5)
                        {
                            haircolorValue = "Yellow";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int eyebrows;
                string eyebrowsValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nEYEBROWS: \n1.) Straight\n2.) Rounded\n3.) Thin\n4.) Thick\n5.) Arched");
                        Console.Write("Choice: ");
                        eyebrows = Convert.ToInt32(Console.ReadLine());
                        if (eyebrows == 1)
                        {
                            eyebrowsValue = "Straight";
                            break;
                        }
                        else if (eyebrows == 2)
                        {
                            eyebrowsValue = "Rounded";
                            break;
                        }
                        else if (eyebrows == 3)
                        {
                            eyebrowsValue = "Thin";
                            break;
                        }
                        else if (eyebrows == 4)
                        {
                            eyebrowsValue = "Thick";
                            break;
                        }
                        else if (eyebrows == 5)
                        {
                            eyebrowsValue = "Arched";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int eyeshape;
                string eyeshapeValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nEYE SHAPE: \n1.) Round\n2.) Almond\n3.) Downturned\n4.) Monolid\n5.) Hooded");
                        Console.Write("Choice: ");
                        eyeshape = Convert.ToInt32(Console.ReadLine());
                        if (eyeshape == 1)
                        {
                            eyeshapeValue = "Round";
                            break;
                        }
                        else if (eyeshape == 2)
                        {
                            eyeshapeValue = "Almond";
                            break;
                        }
                        else if (eyeshape == 3)
                        {
                            eyeshapeValue = "Downturned";
                            break;
                        }
                        else if (eyeshape == 4)
                        {
                            eyeshapeValue = "Monolid";
                            break;
                        }
                        else if (eyeshape == 5)
                        {
                            eyeshapeValue = "Hooded";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int eyecolor;
                string eyecolorValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nEYE COLOR: \n1.) Brown\n2.) Blue\n3.) Green\n4.) Hazel\n5.) Gray");
                        Console.Write("Choice: ");
                        eyecolor = Convert.ToInt32(Console.ReadLine());
                        if (eyecolor == 1)
                        {
                            eyecolorValue = "Brown";
                            break;
                        }
                        else if (eyecolor == 2)
                        {
                            eyecolorValue = "Blue";
                            break;
                        }
                        else if (eyecolor == 3)
                        {
                            eyecolorValue = "Green";
                            break;
                        }
                        else if (eyecolor == 4)
                        {
                            eyecolorValue = "Hazel";
                            break;
                        }
                        else if (eyecolor == 5)
                        {
                            eyecolorValue = "Gray";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int liptypes;
                string liptypesValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nLIP TYPES: \n1.) Full lips\n2.) Wide lips\n3.) Thin lips\n4.) Heart-shaped lips\n5.) Round lips");
                        Console.Write("Choice: ");
                        liptypes = Convert.ToInt32(Console.ReadLine());
                        if (liptypes == 1)
                        {
                            liptypesValue = "Full lips";
                            break;
                        }
                        else if (liptypes == 2)
                        {
                            liptypesValue = "Wide lips";
                            break;
                        }
                        else if (liptypes == 3)
                        {
                            liptypesValue = "Thin lips";
                            break;
                        }
                        else if (liptypes == 4)
                        {
                            liptypesValue = "Heart-shaped lips";
                            break;
                        }
                        else if (liptypes == 5)
                        {
                            liptypesValue = "Round lips";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int lipcolor;
                string lipcolorValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nLIP COLOR: \n1.) Red\n2.) Pink\n3.) Orange\n4.) Brown\n5.) Nude");
                        Console.Write("Choice: ");
                        lipcolor = Convert.ToInt32(Console.ReadLine());
                        if (lipcolor == 1)
                        {
                            lipcolorValue = "Red";
                            break;
                        }
                        else if (lipcolor == 2)
                        {
                            lipcolorValue = "Pink";
                            break;
                        }
                        else if (lipcolor == 3)
                        {
                            lipcolorValue = "Orange";
                            break;
                        }
                        else if (lipcolor == 4)
                        {
                            lipcolorValue = "Brown";
                            break;
                        }
                        else if (lipcolor == 5)
                        {
                            lipcolorValue = "Nude";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int bodytype;
                string bodytypeValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nBODY TYPE: \n1.) Skinny\n2.) Average\n3.) Muscular\n4.) Fat");
                        Console.Write("Choice: ");
                        bodytype = Convert.ToInt32(Console.ReadLine());
                        if (bodytype == 1)
                        {
                            bodytypeValue = "Skinny";
                            break;
                        }
                        else if (bodytype == 2)
                        {
                            bodytypeValue = "Average";
                            break;
                        }
                        else if (bodytype == 3)
                        {
                            bodytypeValue = "Muscular";
                            break;
                        }
                        else if (bodytype == 4)
                        {
                            bodytypeValue = "Fat";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int top;
                string topValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nTOP: \n1.) T-shirt\n2.) Tank top\n3.) Blouse\n4.) Polo shirt\n5.) Sweater");
                        Console.Write("Choice: ");
                        top = Convert.ToInt32(Console.ReadLine());
                        if (top == 1)
                        {
                            topValue = "T-shirt";
                            break;
                        }
                        else if (top == 2)
                        {
                            topValue = "Tank top";
                            break;
                        }
                        else if (top == 3)
                        {
                            topValue = "Blouse";
                            break;
                        }
                        else if (top == 4)
                        {
                            topValue = "Polo shirt";
                            break;
                        }
                        else if (top == 5)
                        {
                            topValue = "Sweater";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int topcolor;
                string topcolorValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nTOP COLOR: \n1.) Black\n2.) White\n3.) Green\n4.) Red\n5.) Blue");
                        Console.Write("Choice: ");
                        topcolor = Convert.ToInt32(Console.ReadLine());
                        if (topcolor == 1)
                        {
                            topcolorValue = "Black";
                            break;
                        }
                        else if (topcolor == 2)
                        {
                            topcolorValue = "White";
                            break;
                        }
                        else if (topcolor == 3)
                        {
                            topcolorValue = "Green";
                            break;
                        }
                        else if (topcolor == 4)
                        {
                            topcolorValue = "Red";
                            break;
                        }
                        else if (topcolor == 5)
                        {
                            topcolorValue = "Blue";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int bottom;
                string bottomValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nBOTTOM: \n1.) Shorts\n2.) Pants\n3.) Skirt");
                        Console.Write("Choice: ");
                        bottom = Convert.ToInt32(Console.ReadLine());
                        if (bottom == 1)
                        {
                            bottomValue = "Shorts";
                            break;
                        }
                        else if (bottom == 2)
                        {
                            bottomValue = "Shorts";
                            break;
                        }
                        else if (bottom == 3)
                        {
                            bottomValue = "Shorts";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int bottomcolor;
                string bottomcolorValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nBOTTOM COLOR: \n1.) Black\n2.) White\n3.) Green\n4.) Red\n5.) Blue");
                        Console.Write("Choice: ");
                        bottomcolor = Convert.ToInt32(Console.ReadLine());
                        if (bottomcolor == 1)
                        {
                            bottomcolorValue = "Black";
                            break;
                        }
                        else if (bottomcolor == 2)
                        {
                            bottomcolorValue = "White";
                            break;
                        }
                        else if (bottomcolor == 3)
                        {
                            bottomcolorValue = "Green";
                            break;
                        }
                        else if (bottomcolor == 4)
                        {
                            bottomcolorValue = "Red";
                            break;
                        }
                        else if (bottomcolor == 5)
                        {
                            bottomcolorValue = "Blue";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int footwear;
                string footwearValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nFOOTWEAR: \n1.) Sneakers\n2.) Heels\n3.) Slippers\n4.) Boots\n5.) Sandals");
                        Console.Write("Choice: ");
                        footwear = Convert.ToInt32(Console.ReadLine());
                        if (footwear == 1)
                        {
                            footwearValue = "Sneakers";
                            break;
                        }
                        else if (footwear == 2)
                        {
                            footwearValue = "Heels";
                            break;
                        }
                        else if (footwear == 3)
                        {
                            footwearValue = "Slippers";
                            break;
                        }
                        else if (footwear == 4)
                        {
                            footwearValue = "Boots";
                            break;
                        }
                        else if (footwear == 5)
                        {
                            footwearValue = "Sandals";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int accessories;
                string accessoriesValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nACCESSORIES: \n1.) Watch\n2.) Necklace\n3.) Bracelet\n4.) Earrings\n5.) Hat");
                        Console.Write("Choice: ");
                        accessories = Convert.ToInt32(Console.ReadLine());
                        if (accessories == 1)
                        {
                            accessoriesValue = "Watch";
                            break;
                        }
                        else if (accessories == 2)
                        {
                            accessoriesValue = "Necklace";
                            break;
                        }
                        else if (accessories == 3)
                        {
                            accessoriesValue = "Bracelet";
                            break;
                        }
                        else if (accessories == 4)
                        {
                            accessoriesValue = "Earrings";
                            break;
                        }
                        else if (accessories == 5)
                        {
                            accessoriesValue = "Hat";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int occupation;
                string occupationValue;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nOCCUPATION: \n1.) Doctor\n2.) Entrepreneur\n3.) Lawyer\n4.) Student\n5.) Teacher");
                        Console.Write("Choice: ");
                        occupation = Convert.ToInt32(Console.ReadLine());
                        if (occupation == 1)
                        {
                            occupationValue = "Doctor";
                            break;
                        }
                        else if (occupation == 2)
                        {
                            occupationValue = "Entrepreneur";
                            break;
                        }
                        else if (occupation == 3)
                        {
                            occupationValue = "Lawyer";
                            break;
                        }
                        else if (occupation == 4)
                        {
                            occupationValue = "Student";
                            break;
                        }
                        else if (occupation == 5)
                        {
                            occupationValue = "Teacher";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("!! Invalid Input, Try Again !!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                int Timid, Expressive, Cheerful, Calm, Aggressive;

                while (true)
                {
                    try
                    {
                        Console.WriteLine("\n\n[Character Status]\n");
                        Console.WriteLine("Please enter 1-100 only for each category. Thank you!\n");

                        Console.Write("Timid: ");
                        Timid = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Expressive: ");
                        Expressive = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Cheerful: ");
                        Cheerful = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Calm: ");
                        Calm = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Aggressive: ");
                        Aggressive = Convert.ToInt32(Console.ReadLine());

                        if (Timid >= 1 && Timid <= 100 &&
                            Expressive >= 1 && Expressive <= 100 &&
                            Cheerful >= 1 && Cheerful <= 100 &&
                            Calm >= 1 && Calm <= 100 &&
                            Aggressive >= 1 && Aggressive <= 100)
                        {
                            Console.WriteLine("\nCharacter creation complete!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input, Please enter 1-100 only for each category.");

                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }

                CharacterAppearance appearance = new CharacterAppearance
                {
                    Faceshape = faceshapeValue,
                    Skincolor = skincolorValue,
                    Hairstyle = hairstyleValue,
                    Haircolor = haircolorValue,
                    Eyebrows = eyebrowsValue,
                    Eyeshape = eyeshapeValue,
                    Eyecolor = eyecolorValue,
                    Liptypes = liptypesValue,
                    Lipcolor = lipcolorValue,
                    Bodytype = bodytypeValue,
                    Top = topValue,
                    Topcolor = topcolorValue,
                    Bottom = bottomValue,
                    Bottomcolor = bottomcolorValue,
                    Footwear = footwearValue,
                    Accessories = accessoriesValue,
                    Occupation = occupationValue,

                };

                CharacterStats stats = new CharacterStats
                {
                    Timid = Timid,
                    Expressive = Expressive,
                    Cheerful = Cheerful,
                    Calm = Calm,
                    Aggressive = Aggressive,
                };

                CharacterInformation info = new CharacterInformation
                {
                    Name = name,
                    Age = ageValue,
                    Gender = genderValue,
                    Married = marryValue,
                    Appearance = appearance,
                    Stats = stats
                };

                information = new CharacterSimulator(info.Name, info.Age, info.Gender, info.Married, info.Appearance, info.Stats);
                information.DisplayCharacterInformation(name);
                information.DisplayCharacterInformation();

                string Insert = "INSERT INTO dbo.charactertable (user_name, user_age, user_gender, user_married, user_faceshape, user_skincolor, user_hairstyle, user_haircolor," +
    " user_eyebrows, user_eyeshape, user_eyecolor, user_liptypes, user_lipcolor, user_bodytype, user_top, user_topcolor, user_bottom, user_bottomcolor, user_footwear," +
    " user_accessories, user_occupation, user_timid, user_expressive, user_cheerful, user_calm, user_aggressive) " +
    "VALUES (@Name, @Age, @Gender, @Married, @FaceShape, @SkinColor, @Hairstyle, @HairColor, @Eyebrows, @EyeShape, @EyeColor, @LipTypes, @LipColor, @BodyType, @Top, @TopColor, @Bottom, @BottomColor, @Footwear," +
    " @Accessories, @Occupation, @Timid, @Expressive, @Cheerful, @Calm, @Aggressive)";

                using (SqlCommand InsertData = new SqlCommand(Insert, SqlConnection))
                {
                    InsertData.Parameters.AddWithValue("@Name", information.Features.Name);
                    InsertData.Parameters.AddWithValue("@Age", information.Features.Age);
                    InsertData.Parameters.AddWithValue("@Gender", information.Features.Gender);
                    InsertData.Parameters.AddWithValue("@Married", (information.Features.Married ? 0 : 1));

                    InsertData.Parameters.AddWithValue("@FaceShape", information.Features.Appearance.Faceshape);
                    InsertData.Parameters.AddWithValue("@SkinColor", information.Features.Appearance.Skincolor);
                    InsertData.Parameters.AddWithValue("@Hairstyle", information.Features.Appearance.Hairstyle);
                    InsertData.Parameters.AddWithValue("@HairColor", information.Features.Appearance.Haircolor);
                    InsertData.Parameters.AddWithValue("@Eyebrows", information.Features.Appearance.Eyebrows);
                    InsertData.Parameters.AddWithValue("@EyeShape", information.Features.Appearance.Eyeshape);
                    InsertData.Parameters.AddWithValue("@EyeColor", information.Features.Appearance.Eyecolor);
                    InsertData.Parameters.AddWithValue("@LipTypes", information.Features.Appearance.Liptypes);
                    InsertData.Parameters.AddWithValue("@LipColor", information.Features.Appearance.Lipcolor);
                    InsertData.Parameters.AddWithValue("@BodyType", information.Features.Appearance.Bodytype);
                    InsertData.Parameters.AddWithValue("@Top", information.Features.Appearance.Top);
                    InsertData.Parameters.AddWithValue("@TopColor", information.Features.Appearance.Topcolor);
                    InsertData.Parameters.AddWithValue("@Bottom", information.Features.Appearance.Bottom);
                    InsertData.Parameters.AddWithValue("@BottomColor", information.Features.Appearance.Bottomcolor);
                    InsertData.Parameters.AddWithValue("@Footwear", information.Features.Appearance.Footwear);
                    InsertData.Parameters.AddWithValue("@Accessories", information.Features.Appearance.Accessories);
                    InsertData.Parameters.AddWithValue("@Occupation", information.Features.Appearance.Occupation);

                    InsertData.Parameters.AddWithValue("@Timid", information.Features.Stats.Timid);
                    InsertData.Parameters.AddWithValue("@Expressive", information.Features.Stats.Expressive);
                    InsertData.Parameters.AddWithValue("@Cheerful", information.Features.Stats.Cheerful);
                    InsertData.Parameters.AddWithValue("@Calm", information.Features.Stats.Calm);
                    InsertData.Parameters.AddWithValue("@Aggressive", information.Features.Stats.Aggressive);


                    try
                    {
                        if (SqlConnection.State != ConnectionState.Open)
                        {
                            SqlConnection.Open();
                        }

                        InsertData.ExecuteNonQuery();
                        Console.WriteLine("\n[Data Stored Successfully]");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    finally
                    {
                        if (SqlConnection.State == ConnectionState.Open)
                        {
                            SqlConnection.Close();
                        }
                    }
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
        public override void DisplayCharacterInformation()
        {
            Console.WriteLine("\n\n[Here's your full details]\n");
            Console.WriteLine("Name: " + Features.Name);
            Console.WriteLine("Age Groups: " + Features.Age);
            Console.WriteLine("Gender: " + Features.Gender);
            Console.WriteLine("Married: " + (Features.Married ? "Yes" : "No"));

            Console.WriteLine("Faceshape: " + Features.Appearance.Faceshape);
            Console.WriteLine("Skincolor: " + Features.Appearance.Skincolor);
            Console.WriteLine("Hairstyle: " + Features.Appearance.Hairstyle);
            Console.WriteLine("Haircolor: " + Features.Appearance.Haircolor);
            Console.WriteLine("Eyebrows: " + Features.Appearance.Eyebrows);
            Console.WriteLine("Eyeshape: " + Features.Appearance.Eyeshape);
            Console.WriteLine("Eyecolor: " + Features.Appearance.Eyecolor);
            Console.WriteLine("Liptypes: " + Features.Appearance.Liptypes);
            Console.WriteLine("Lipcolor: " + Features.Appearance.Lipcolor);
            Console.WriteLine("Bodytype: " + Features.Appearance.Bodytype);
            Console.WriteLine("Top: " + Features.Appearance.Top);
            Console.WriteLine("Topcolor: " + Features.Appearance.Topcolor);
            Console.WriteLine("Bottom: " + Features.Appearance.Bottom);
            Console.WriteLine("Bottomcolor: " + Features.Appearance.Bottomcolor);
            Console.WriteLine("Footwear: " + Features.Appearance.Footwear);
            Console.WriteLine("Accessories: " + Features.Appearance.Accessories);
            Console.WriteLine("Occupation: " + Features.Appearance.Occupation);

            Console.WriteLine("PERSONALITY (IN %)");
            Console.WriteLine("Timid: " + Features.Stats.Timid + "%");
            Console.WriteLine("Expressive: " + Features.Stats.Expressive + "%");
            Console.WriteLine("Cheerful: " + Features.Stats.Cheerful + "%");
            Console.WriteLine("Calm: " + Features.Stats.Calm + "%");
            Console.WriteLine("Aggressive: " + Features.Stats.Aggressive + "%");
        }

        public void DisplayCharacterInformation(string name)
        {
            Console.WriteLine(name + " has been successfully created!");
        }
        public void CreateCharacter()
        {
            CharacterCreation();
        }
        public void DisplayCharacter()
        {

            try
            {
                string DatabaseConnection = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ACER\SOURCE\REPOS\COMPROGFINALTP\COMPROGFINALTP\COMPROGDATABASE.MDF;Integrated Security=True;";

                using (SqlConnection SqlConnection = new SqlConnection(DatabaseConnection))
                {
                    SqlConnection.Open();

                    string selectQuery = "SELECT * FROM dbo.charactertable";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, SqlConnection);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {

                        bool IfCharacterExist = false;

                        while (reader.Read())
                        {
                            Console.WriteLine("\n[List of all characters]\n");
                            Console.WriteLine("\nCharacter Details:");

                            Console.WriteLine($"\nCharacter ID: {reader["user_id"]}");
                            Console.WriteLine($"Name: {reader["user_name"]}");
                            Console.WriteLine($"Age: {reader["user_age"]}");
                            Console.WriteLine($"Gender: {reader["user_gender"]}");
                            Console.WriteLine($"Married: {(bool)reader["user_married"]}");

                            Console.WriteLine("Appearance:");
                            Console.WriteLine($"Face Shape: {reader["user_faceshape"]}");
                            Console.WriteLine($"Skin Color: {reader["user_skincolor"]}");
                            Console.WriteLine($"Hairstyle: {reader["user_hairstyle"]}");
                            Console.WriteLine($"Hair Color: {reader["user_haircolor"]}");
                            Console.WriteLine($"Eyebrows: {reader["user_eyebrows"]}");
                            Console.WriteLine($"Eye Shape: {reader["user_eyeshape"]}");
                            Console.WriteLine($"Eye Color: {reader["user_eyecolor"]}");
                            Console.WriteLine($"Lip Types: {reader["user_liptypes"]}");
                            Console.WriteLine($"Lip Color: {reader["user_lipcolor"]}");
                            Console.WriteLine($"Body Type: {reader["user_bodytype"]}");

                            Console.WriteLine("Outfit:");
                            Console.WriteLine($"Top: {reader["user_top"]}");
                            Console.WriteLine($"Top Color: {reader["user_topcolor"]}");
                            Console.WriteLine($"Bottom: {reader["user_bottom"]}");
                            Console.WriteLine($"Bottom Color: {reader["user_bottomcolor"]}");
                            Console.WriteLine($"Footwear: {reader["user_footwear"]}");
                            Console.WriteLine($"Accessories: {reader["user_accessories"]}");

                            Console.WriteLine($"Occupation: {reader["user_occupation"]}");

                            Console.WriteLine("Personality (in %):");
                            Console.WriteLine($"Timid: {reader["user_timid"]}");
                            Console.WriteLine($"Expressive: {reader["user_expressive"]}");
                            Console.WriteLine($"Cheerful: {reader["user_cheerful"]}");
                            Console.WriteLine($"Calm: {reader["user_calm"]}");
                            Console.WriteLine($"Aggressive: {reader["user_aggressive"]}");

                            IfCharacterExist = true;
                            Console.WriteLine("--------------------------");
                        }
                        if (!IfCharacterExist)
                        {
                            Console.WriteLine("\n!! Database is empty !!");
                            isDBEmpty = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        bool isDBEmpty = false;
        public void RemoveCharacter()
        {
            while (true)
            {
                try
                {

                    DisplayCharacter();
                    if (isDBEmpty)
                    {
                        break;
                    }
                    Console.Write("\nEnter the Character ID to remove: ");
                    int characterIdToRemove = Convert.ToInt32(Console.ReadLine());

                    string DatabaseConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\ACER\SOURCE\REPOS\COMPROGFINALTP\COMPROGFINALTP\COMPROGDATABASE.MDF;Integrated Security=True;";
                    using (SqlConnection SqlConnection = new SqlConnection(DatabaseConnection))
                    {
                        SqlConnection.Open();

                        string deleteQuery = "DELETE FROM dbo.charactertable WHERE user_id = @characterIdToRemove";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, SqlConnection);
                        deleteCommand.Parameters.AddWithValue("@characterIdToRemove", characterIdToRemove);

                        int rowsaffected = deleteCommand.ExecuteNonQuery();


                        Console.Write("\nAre you sure you want to remove this character? Changes will be permanent. \n1.Yes \n2. No \nChoice:");
                        int removeconfirmation = Convert.ToInt32(Console.ReadLine());

                        if (rowsaffected > 0 && removeconfirmation == 1)
                        {
                            Console.WriteLine("Data has been deleted!");
                            break;
                        }
                        else if (removeconfirmation == 2)
                        {
                            Console.WriteLine("\nYou have cancelled your character removal.");
                        }
                        else
                        {
                            Console.WriteLine("\n !! No data found. !!");
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);

                }
            }

        }
        public static void Main(string[] args)
        {

            CharacterSimulator character = new CharacterSimulator();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n[CHARACTER SIMULATOR!]");
                    Console.WriteLine("Welcome! Unleash your creativity and prepare yourself for an amazing journey of design and self-expression as you realize your individual vision.\n" +
                "You have the ability to create the ideal avatar by choosing the hairstyles, clothes, and accessories!\n");

                    Console.WriteLine("\n1.) Create a new Character\n2.) Display Character\n3.) Remove Character\n4.) Exit");
                    Console.Write("Choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        character.CreateCharacter();
                    }
                    else if (choice == 2)
                    {
                        character.DisplayCharacter();
                    }
                    else if (choice == 3)
                    {
                        character.RemoveCharacter();
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("\nThank you for using our program!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("!! Invalid Input, Try Again !!");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("!! Invalid Input, Try Again !!");
                }
            }
        }
    }
}
