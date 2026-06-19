using System;

namespace Appliccation_code
{
    class SQL
    {
        public static string CreateStudentsTable =
            @"CREATE TABLE Students(
                StudentId INT PRIMARY KEY,
                StudentName VARCHAR(100),
                Email VARCHAR(100),
                Department VARCHAR(50)
            );";
    }
}