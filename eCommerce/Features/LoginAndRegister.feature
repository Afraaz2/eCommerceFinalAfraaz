Feature: Login to e commerce site and purchase an item of clothing with a coupon applied

The test will login to an e-commerce site as a registered user, purchase an item of clothing, apply a discount code and check that the total is correct after the discount & shipping is applied. 


Scenario: Login to valid user account
	Given I am on the website homepage and click the My Account button 
	Then I can proceed to login page and login using valid details
	When I have arrived on the My account page I can access the shop page


