using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationTests
{
    [TestClass]
    public class FluentValidationTests
    {
        private SegmentEdit _edit;
        private SegmentEditValidator _validator;

        public FluentValidationTests()
        {
            this._validator = new SegmentEditValidator();
            this._edit = new SegmentEdit()
            {
                FIPS = "27425",
                ROUTE = "COLLEGE AVE",
                SEGMPREFIX = "N"
            };
            
        }

        [TestMethod]
        public void IsNotValid_FIPS()
        {
            // arrange
            this._edit.FIPS = "";

            // act 
            var result = this._validator.Validate(this._edit);

            // assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void IsNotValid_ROUTE()
        {
            // arrange
            this._edit.ROUTE = "THIS IS REALLY LONG";

            // act 
            var result = this._validator.Validate(this._edit);

            // assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void IsNotValid_SEGMDIR()
        {
            // arrange
            this._edit.SEGMPREFIX = "";

            // act 
            var result = this._validator.Validate(this._edit);

            // assert
            Assert.IsTrue(result.IsValid);
        }
    }
}
