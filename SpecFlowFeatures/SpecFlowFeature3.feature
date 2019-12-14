Feature: SpecFlowFeature3
	In order to get important information
	As a user
	I want to count paragraphs containing word lorem

@mytag
Scenario: Count paragraphs containing word "Lorem"
	Given I have opened Home Page
	When I generate Lorem Ipsum 10 times and count the average result
	Then the average result should not be less than 1 paragraphs containing word Lorem in 10 times reload 
