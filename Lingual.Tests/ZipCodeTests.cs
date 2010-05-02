using Lingual;
using Lingual.Fluent.Bdd;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace Something.Domain.Demographic
{
    public class ZipCodeTestingContext : TestContext
    {
        private string _stringToParse;
        private int _expectedFirstSection;

        public void has_this_string(string zip)
        {
            _stringToParse = zip;
        }

        public void should_expect_for_first_part(int expected)
        {
            _expectedFirstSection = expected;
        }

        public string the_string_that_I_should_parse
        {
            get { return _stringToParse; }
        }

        public int expected_first_part
        {
            get { return _expectedFirstSection; }
        }
    }

    public class Zip_code_test_base
    {
        protected void is_a_valid_short_zip_code_string(ZipCodeTestingContext context)
        {
            context.has_this_string("12345");
            context.should_expect_for_first_part(12345);
        }

        protected ZipCode parsing_the_string_to_zip_code(ZipCodeTestingContext context)
        {
            return ZipCode.Parse(context.the_string_that_I_should_parse);
        }
    }

    public class Parse_zip_code_from_a_valid_short_string : Zip_code_test_base
    {
        public ISpecificationSource Parse_a_valid_short_zip_code_string
        {
            get
            {
                return Given.a<ZipCodeTestingContext>()
                    .that(is_a_valid_short_zip_code_string)
                    .when(parsing_the_string_to_zip_code)
                    .then(the_first_part_of_the_zip_code_should_be_as_expected);
            }
        }

        public void the_first_part_of_the_zip_code_should_be_as_expected(ZipCodeTestingContext context, ZipCode zipCode)
        {
            Assert.AreEqual(context.expected_first_part, zipCode.Zip);
        }
    }
}