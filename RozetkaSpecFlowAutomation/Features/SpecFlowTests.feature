Feature: SpecFlowTests
	As a Rozetka user
    I want to be able to choose a product
    I want to be able to buy a product
    I want to check the amount of goods

@smoke
Scenario Outline: Buy a product
	Given I open official Rozetka web site
	When I choose a product by text '<text>'
	And I sort a product by brand '<brand>'
	And I sort a products '<sort>'
	And I choose a products from list
	Then check amount '<amount>'

	Examples: 
	| text      | brand   | sort | amount |
	| Ноутбуки  | ASUS    | 2    | 300000 |
	| Телевизор | Samsung | 1    | 10000  |
	| Кресло    | IKEA    | 2    | 20000  |