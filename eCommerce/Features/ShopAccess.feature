Feature: Checkout

A short summary of the feature
Background: 
	Given I am on the website homepage
	Then  I login as a valid user account


Scenario: Add item to shopping cart
	Given I am currently on the shop page
	Then I can add an item to my cart and view the cart
	When I add an item to the cart and apply an coupon
	Then The coupon gives a discount on the retail value