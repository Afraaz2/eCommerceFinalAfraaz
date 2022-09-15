Feature: Checkout

A short summary of the feature
Background: 
	Given I am on the website homepage
	Then  I login as a valid user account

Scenario: Add item to shopping cart
	//Given I am on the shop page 
	Then I can add an item to my cart and view the cart
	Then Item is in cart and I can apply a coupon
	Then The coupon gives a discount equivalent to 15% of the retail value