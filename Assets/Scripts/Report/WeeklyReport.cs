namespace Report
{
    public struct WeeklyReport
    {
        public int Week
        {
            get;
        }

        public int MaxWeek
        {
            get;
        }
        
        public int CorrectionRate
        {
            get;
        }

        public int CorrectGradeRate
        {
            get;
        }

        public int Salery
        {
            get;
        }

        public int Briebe
        {
            get;
        }

        public bool IsStrike
        {
            get;
        }

        public WeeklyReport(int week, int maxWeek, int correctionRate, int correctGradeRate, int salery, int briebe)
        {
            Week = week;
            MaxWeek = maxWeek;
            CorrectionRate = correctionRate;
            Salery = salery;
            Briebe = briebe;
            CorrectGradeRate = correctGradeRate;

            IsStrike = CorrectGradeRate <= 30;
        }
    }
}