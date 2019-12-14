Feature: SpecFlowFeature2
	In order to "Generate characters" 
	As a user
	I want to generate specific number of characters

@mytag
Scenario: Generate specific number of characters
	Given I have opened homepage
	And I have chosen <characters> characters to generate
	When I generate Lorem Ipsum
	Then the result should be <expectedNumber> characters
	Examples: 
| characters | expectedNumber |
| 100        | 100            |
| 500        | 500            |
| 0          | 0              |
