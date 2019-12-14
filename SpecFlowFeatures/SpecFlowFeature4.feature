Feature: SpecFlowFeature4
	In order to check site
	As a user
	I want to check that Lorem Ipsum in russian contains word  "рыба"

@mytag
Scenario: Ensure that Lorem Ipsum in russian contains word  "рыба"
	Given Open the home page
	And I choose russian language
	Then the text should contain at least 1 word  defined "рыба"
