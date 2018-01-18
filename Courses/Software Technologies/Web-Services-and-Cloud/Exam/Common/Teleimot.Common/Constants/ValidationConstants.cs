namespace Teleimot.Common.Constants
{
    public static class ValidationConstants
    {
        public const int EstateTitleMaxLength = 50;
        public const int EstateTitleMinLength = 5;

        public const int EstateDescriptionMaxLength = 1000;
        public const int EstateDescriptionMinLength = 10;

        public const int EstateMinConstructionYear = 1800;

        public const int CommentsContentMaxLength = 500;
        public const int CommentsContentMinLength = 10;

        public const int RatingsMinValue = 1;
        public const int RatingsMaxValue = 5;
        
        public const int UsernameMaxLength = 100;

        public const int EstateContactMaxLength = 128;

        public const int TakeMaxValue = 100;
        public const int SkipMaxValue = 100;
        public const int TakeDefaultValue = 10;
        public const int SkipDefaultValue = 0;
    }
}