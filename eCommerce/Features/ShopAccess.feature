Feature: Checkout

A short summary of the feature
Background: 
	Given I am on the website homepage
	When  I login as a valid user account
	And I am on the shop page

@TestCase1
Scenario: Add item to shopping cart and check if Coupon works, then log out
	When I add an item to my cart and view the cart
	When I add an item to the cart and apply coupon edgewords
	Then The coupon gives a discount of 15% on the retail value


@TestCase2
Scenario: Purchase an item of clothing and go through. Check my order detail
	When I add an item to my cart and view the cart
	When I proceed to check out and fill out all key information
	When I complete order and fetch the order number 
	Then I can navigate to my orders and check the same order shows in the account

	#Too many thens, no thens in backgrond
