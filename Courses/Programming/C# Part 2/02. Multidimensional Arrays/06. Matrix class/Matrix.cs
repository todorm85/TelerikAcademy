using System;

class Matrix
{
    // private means that this var can only be accessed from within the current clas only
    private int[,] matrix;

    // first make constructor to assign the initial state of our object of this class. The constructor is a method but it only has a type and no name!
    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }

    // next we create property for our class that returns number of rows for the matrix, this means we are working with current instance (the matrix that this property is called for).
    public int Rows
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }

    public int Columns
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }

    // this is the indexer to acces matrix values. It is used to acces the values written in the matrix. It is of type int because the values in the matrix are of type int and we know it
    public int this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }

        set
        {
            this.matrix[row, col] = value;
        }
    }

    // overloading operator is to make it do something else for objects of this class
    public static Matrix operator + (Matrix first, Matrix second)
    {
        // we assume that the two matrixes will always be with valid equal rows and equal columns, otherwise we need to specify exception
        Matrix result = new Matrix(first.Rows,first.Columns);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] + second[row, col];
            }
        }

        return result;
    }

    public static Matrix operator * (Matrix first, Matrix second)
    {
        // we assume that the two matrixes will always be with valid equal rows and equal columns, otherwise we need to specify exception
        Matrix result = new Matrix(first.Rows, first.Columns);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] * second[row, col];
            }
        }

        return result;
    }

    public static Matrix operator - (Matrix first, Matrix second)
    {
        // we assume that the two matrixes will always be with valid equal rows and equal columns, otherwise we need to specify exception
        Matrix result = new Matrix(first.Rows, first.Columns);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] - second[row, col];
            }
        }

        return result;
    }

    public override string ToString()
    {
        string result = null;
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                result += this[row, col] + " ";
            }

            result += "\n";
        }

    return result;
    }
}

