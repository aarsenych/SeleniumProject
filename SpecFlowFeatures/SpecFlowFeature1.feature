Feature: SpecFlowFeature1
	In order to "Generate paragraphs" 
	As a user
	I want to generate specific number of paragraphs

@mytag
Scenario Outline: Generate some number of paragraphs
	Given I have opened home page 
	And I have chosen <paragraphs> paragraphs to generate
	When I generate paragraphs
	Then the result should be <resultParagraphs> paragraphs generated
	Examples: 
| paragraphs | resultParagraphs |
| 10         | 10               |
| 20         | 20               |
| 0          | 0                |
| -1         | -1               |
| 5          | 5                |

