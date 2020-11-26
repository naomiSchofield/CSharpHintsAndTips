using System;
using Xunit;
namespace Session1
{
    public class Session1
    {
        /*
         * Binary comparison operators (==, !=, >, <, >=, <=) will always take the form 'expression comparison expression' and output a boolean
         * An 'expression' is something that outputs or 'evaluates' to a value
         */
        [Fact]
        public void Binary_Comparisons()
        {
            bool result;
            result = 'b' == 'b';
            result = 'b' != 'c';
            result = 3 < 1;
            result = 20 > 10;
            /*
               Above we're using 'literal expressions' to the left and right of the comparison operators
               Literal expressions evaluate to the value they are; 'b' evaluates to 'b', 3 evaluates to 3 ...well duh, obvious right.
               So what's happening below?
            */
            result = SeansTeachingScore() > StevesTeachingScore();
            /*
                Well here the expressions 'SeansTeachingScore()' and 'StevesTeachingScore()' are methods. They're each evaluated first to a value:
                SeansTeachingScore() returns/evaluates to 101
                StevesTeachingScore() returns/evaluates to 100
                ...(shh don't tell Steve) and then the values are compared. So it's almost like I typed:
                result = 101 > 100;
                ...make sense?           
            */
        }
        [Fact]
        public void MemberVariablesAndScope()
        {
            var sensibleNameForADog = "Sausages";
            var sausages = new Dog(sensibleNameForADog); // Go below to see the dog class
            var isSensibleName = sausages.IsSensibleDogName();
            // Just like name was only accessible inside Dogs constructor. When we leave this function: sensibleNameForADog, dog & isSensibleName
            // will go 'out of scope'
        }
        // Uncommenting the line below will cause a compiler error...
        // sausages.IsSensibleDogName();
        [Fact]
        public void ConditionalsInsideLoop()
        {
            // Sean & Steve go on a night out with the intent to drink 20 beers. A disaster because Sean's a lightweight and Steve has hollow legs...
            for (int beerCount = 0; beerCount < 20; beerCount++)
            {
                // This if statement runs/evaluates every time we run through the loop. But it only evaluates to 'true' the first time
                if (beerCount == 0)
                {
                    // ...so this line is only executed once on the very first loop through (when beerCount is 0)
                    Console.WriteLine($"Sean and Steve say where's our beer");
                }
                else
                {
                    // This line will run when the if statement is false (so every other loop through)
                    Console.WriteLine($"Sean and Steve drink beer {beerCount}");
                }
                // This if statement runs/evaluates every time we run through the loop. But it only evaluates to 'true' when beerCount is 10
                if (beerCount == 10)
                {
                    // ...at which point the line below is executed and the method returns (so we never do loops 11,12,13,14,15,16,17,18,19)
                    return; // home Sean you've got to get up with the kids tomorrow and you'll regret all of this
                }
            }
        }
        private int StevesTeachingScore()
        {
            return 100;
        }
        private int SeansTeachingScore()
        {
            return 101;
        }
        public class Dog
        {
            // Hey! I'm called a field or member variable. I'm accessible from any method in the class and I exist the whole time an instance
            // of the class does
            private string _name;
            public Dog(string name)
            {
                // The name variable only exists within this scope (anything between the brackets)
                _name = name;
                // Honest! See below...
            }
            public bool IsSensibleDogName()
            {
                // If you uncomment the line below you'll see a compiler error. Name was only accessible in the constructor above.
                // return name == "Sausages";
                // The field _name however...
                return _name == "Sausages";
            }
        }
    }
}