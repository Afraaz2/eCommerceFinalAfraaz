Feature: Checkout

A short summary of the feature
Background: 
	Given I am on the website homepage
	Then  I login as a valid user account

@TestCase1
Scenario: Add item to shopping cart and check if Coupon works, then log out
	Given I am currently on the shop page
	Then I can add an item to my cart and view the cart
	When I add an item to the cart and apply an coupon
	Then The coupon gives a discount on the retail value



@TestCase2
Scenario: Purchase an item of clothing and go through. Check my order detail
	Given I am currently on the shop page
	Then I can add an item to my cart and view the cart
	Then I can proceed to check out and fill out all key information
	Then I can Complete order and fetch the order number 
	Then I can navigate to my orders and check the same order shows in the account
