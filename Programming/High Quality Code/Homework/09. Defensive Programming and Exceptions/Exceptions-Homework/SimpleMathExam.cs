using System;

public class SimpleMathExam : Exam
{
    public const int MathExamMaxResult = 6;
    public const int MathExamMinResult = 2;
    public const int MathExamProblemsCount = 10;

    private int problemsSolved;

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0 || MathExamProblemsCount < value)
            {
                throw new ArgumentException("Solved problems cannot be less than zero or greater than ten.");
            }

            this.problemsSolved = value;
        }
    }
    

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        double resultInPercent = (this.ProblemsSolved / MathExamProblemsCount) * 100;

        if (resultInPercent < 60)
        {
            return new ExamResult(2, MathExamMinResult, MathExamMaxResult, "Bad result: Less than 60 percent of exam solved.");
        }
        else if (60 <= resultInPercent && resultInPercent < 70)
        {
            return new ExamResult(3, MathExamMinResult, MathExamMaxResult, "Average result: Between 60 and 70 percent of exam solved.");
        }
        else if (70 <= resultInPercent && resultInPercent < 80)
        {
            return new ExamResult(4, MathExamMinResult, MathExamMaxResult, "Good result: Between 70 and 80 percent of exam solved.");
        }
        else if (80 <= resultInPercent && resultInPercent < 90)
        {
            return new ExamResult(5, MathExamMinResult, MathExamMaxResult, "Very Good result: Between 80 and 90 percent of exam solved.");
        }
        else if (90 <= resultInPercent && resultInPercent <= 100)
        {
            return new ExamResult(6, MathExamMinResult, MathExamMaxResult, "Excellent result: Between 90 and 100 percent of exam solved.");
        }
        else
        {
            throw new ArgumentException("Error during math exam check! Probably invalid number of problems solved!");
        }
    }
}
