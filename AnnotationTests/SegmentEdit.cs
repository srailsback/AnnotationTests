using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
//using ExpressiveAnnotations.Attributes;

namespace AnnotationTests
{
    public class SegmentEdit
    {

        //public SegmentEdit(string fips, Excel.IExcelDataReader reader)
        //{
        //    this.FIPS = fips;
        //}


        [Display(Name = "FIPS")]
        public string FIPS { get; set; }

        [Display(Name = "ROUTE")]
        public string ROUTE { get; set; }

        [Display(Name = "SEGMENT PREFIX")]
        [RegularExpression(@"^$|^[NWES]{1}$", ErrorMessage = "SEGMENT PREFIX must be N, W, E, W, or empty value.")]
        public string SEGMPREFIX { get; set; }

        [Display(Name = "ROUTE NAME")]
        [MaxLength(30, ErrorMessage = "ROUTE NAME cannot exceed 30 characters.")]
        public string ROUTENAME { get; set; }

        [Display(Name = "SEGMENT ID")]
        [Required(ErrorMessage = "SEGMENT ID is required.")]
        [RegularExpression(@"^\d*$", ErrorMessage = "SEGMENT ID must be numeric.")]
        public int SEGMID { get; set; }

        [Display(Name = "FROM FEATURE")]
        [Required(ErrorMessage = "FROM FEATURE is required.")]
        [MaxLength(30, ErrorMessage = "FROM FEATURE cannot exceed 30 characters.")]
        public string FROMFEATURE { get; set; }

        [Display(Name = "SEGMENT DIRECTION")]
        [RegularExpression(@"^$|^(N+(E|W))|(S+(E|W))|[NSEW]$", ErrorMessage = "SEGMENT DIRECTION must be N, W, S, E, NW, NE, SW, SE, or empty value.")]
        public string SEGMDIR { get; set; }

        [Display(Name = "TO FEATURE")]
        [Required(ErrorMessage = "TO FEATURE is required.")]
        [MaxLength(30, ErrorMessage = "TO FEATURE cannot exceed 30 characters.")]
        public string TOFEATURE { get; set; }

        [Display(Name = "FOREST ROUTE")]
        [MaxLength(10, ErrorMessage = "FOREST ROUTE cannot exceed 10 characters")]
        public string FORESTROUTE { get; set; }

        [Display(Name = "LENGTH")]
        [Required(ErrorMessage = "LENGTH is required.")]
        [RegularExpression(@"^\d*$", ErrorMessage = "LENGTH must be numeric.")]
        public decimal LENGTH { get; set; }

        [Display(Name = "SURFACE TYPE")]
        [Required(ErrorMessage = "SURFACE TYPE is required.")]
        [RegularExpression("", ErrorMessage = "SURFACE TYPE is not valid, see Admin Class instructions.")]
        public string PRISURF { get; set; }

        [Display(Name = "SURFACE CONDITION")]
        [Required(ErrorMessage = "SURFACE CONDITION is required.")]
        [RegularExpression("^[GPF]$", ErrorMessage = "SURFACE CONDITION must be G(ood), F(air), or P(oor).")]
        public string PRIPSI { get; set; }

        public decimal dPRIPSI
        {
            get
            {
                if (this.PRIPSI == "G")
                {
                    return 4m;
                }

                if (this.PRIPSI == "F")
                {
                    return 2.5m;
                }

                return 1.0m;
            }
        }

        [Display(Name = "SURFACE WIDTH")]
        [Required(ErrorMessage = "SURFACE WIDTH is required.")]
        [Range(1, 200, ErrorMessage = "SURFACE WIDTH must be between 1 and inches.")]
        public decimal PRISURFWD { get; set; }

        [Display(Name = "THROUGH LANE QUANTITY")]
        [Required(ErrorMessage = "THROUGH LANE QUANTITY is required.")]
        [Range(0, 99, ErrorMessage = "THROUGH LANE QUANTITY must be between 0 and 99.")]
        //[AssertThat("THRULNQTY > 0 && THRULNQTY < PRITRULNWD", ErrorMessage = "THROUGH LANE QUANTITY must be more than 0 and less than THROUGH LANE WIDTH.")]
        public decimal THRULNQTY { get; set; }

        [Display(Name = "THROUGH LANE WIDTH")]
        [Required(ErrorMessage = "THROUGH LANE WIDTH is required.")]
        [Range(0, 999, ErrorMessage = "THROUGH LANE WIDTH must be between 0 and 999.")]
        //[AssertThat("THRULNQTY > 0 && THRULNQTY < PRISURFWD", ErrorMessage = "THROUGH LANE WIDTH must be more than 0 and less than SURFACE WIDTH.")]
        public int PRITHRULNWD { get; set; }

        [Display(Name = "OPERATION")]
        [Required(ErrorMessage = "OPERATION is required.")]
        [RegularExpression(@"^[12]$", ErrorMessage = "OPERATION must be 1 or 2.")]
        public string Operation { get; set; }

        [Display(Name = "OVERLAY THICK")]
        [Required(ErrorMessage = "OVERLAY THICK is required.")]
        [Range(0, 100, ErrorMessage = "OVERLAY THICK must be between 0 and 100.")]
        public decimal PRITREATMENTDEPTH { get; set; }

        [Display(Name = "INSPECTION YEAR")]
        [Range(1952, 2015, ErrorMessage = "INSPECTION YEAR must be between 1952 and 2015.")]
        public string INSPYR { get; set; }

        [Display(Name = "PROJECT YEAR")]
        [Range(1952, 2015, ErrorMessage = "PROJECT YEAR must be between 1952 and 2015.")]
        //[AssertThat("PROJYR >= BUILTYR", ErrorMessage = "PROJECT YEAR must be greater or equal to BUILT YEAR.")]
        public string PROJYR { get; set; }

        [Display(Name = "BUILT YEAR")]
        [Range(1952, 2015, ErrorMessage = "BUILT YEAR must be between 1952 and 2015.")]
        public string BUILTYR { get; set; }

        [Display(Name = "ADMINISTRATIVE CLASS")]
        [Required(ErrorMessage = "ADMINISTRATIVE CLASS is required.")]
        [RegularExpression("", ErrorMessage = "ADMINISTRATIVE CLASS must by 0, 1, 2, 3, 4, 6, 7, 8, or 9. See ADMINISTRATIVE CLASS instructions for more information.")]
        public string ADMINCLASS { get; set; }

        [Display(Name = "JURIDICTIONAL SPLIT")]
        [RegularExpression("", ErrorMessage = "JURIDICTIONAL SPLIT must be 0, 1, 2, 3, or 5. See JURIDICTIONAL SPLIT instructions for more information.")]
        public string JURSPLIT { get; set; }

        [Display(Name = "HOVTYPE")]
        [RegularExpression(@"^$|^\d*$", ErrorMessage = "HOVTYPE must be a number or empty value.")]
        public string HOVTYPE { get; set; }

        [Display(Name = "SEGMENT KEY")]
        [Required(ErrorMessage = "SEGMENT KEY is required")]
        public Guid SEGMENTKEY { get; set; }

    }

}
