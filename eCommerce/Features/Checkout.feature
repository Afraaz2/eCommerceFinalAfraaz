Feature: Login to e commerce site and purchase an item of clothing with a coupon applied

The test will login to an e-commerce site as a registered user, purchase an item of clothing, apply a discount code and check that the total is correct after the discount & shipping is applied. 


Scenario: Login to valid user account
	Given I am on the website homepage and click the My Account button 
	Then I can proceed to login page and login using valid details
	Then I have arrived on the My account page


Scenario: Add item to shopping cart
	Given I am on the website my account page and I click the top shop navigation link
	Then I can add an item to my cart and view the cart
	Then Item is in cart and I can apply a coupon
	Then The coupon gives a discount equivalent to 15% of the retail value