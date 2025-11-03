USE [CloneEbayDB];
GO
INSERT INTO [dbo].[User] ([username], [email], [password], [role], [avatarURL])
VALUES
(N'seller1', N'seller1@example.com', N'AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==', N'seller', N'https://example.com/avatars/seller1.jpg'),
(N'seller2', N'seller2@example.com', N'AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==', N'seller', N'https://example.com/avatars/seller2.jpg'),
(N'seller3', N'seller3@example.com', N'AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==', N'seller', N'https://example.com/avatars/seller3.jpg'),

(N'buyer1', N'buyer1@example.com', N'AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==', N'buyer', N'https://example.com/avatars/buyer1.jpg'),
(N'buyer2', N'buyer2@example.com', N'AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==', N'buyer', N'https://example.com/avatars/buyer2.jpg'),
(N'buyer3', N'buyer3@example.com', N'AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==', N'buyer', N'https://example.com/avatars/buyer3.jpg'),
(N'buyer4', N'buyer4@example.com', N'AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==', N'buyer', N'https://example.com/avatars/buyer4.jpg');
GO
INSERT INTO [dbo].[Category] ([name])
VALUES 
(N'Electronics'),
(N'Fashion'),
(N'Home & Garden'),
(N'Toys & Hobbies'),
(N'Automotive'),
(N'Health & Beauty'),
(N'Sports'),
(N'Books & Media'),
(N'Art & Collectibles'),
(N'Pet Supplies');
GO
INSERT INTO [dbo].[Product]
([title], [description], [price], [images], [categoryId], [sellerId], [isAuction], [auctionEndTime])
VALUES
-- CATEGORY 1: Electronics
(N'iPhone 15 Pro Max 256GB', N'Brand new Apple flagship phone.', 34990000, N'https://example.com/images/iphone15.jpg', 1, 1, 0, NULL),
(N'Samsung Galaxy S24 Ultra', N'Flagship Android device with best camera.', 28990000, N'https://example.com/images/s24ultra.jpg', 1, 1, 0, NULL),
(N'Sony WH-1000XM5', N'Wireless noise-cancelling headphones.', 8990000, N'https://example.com/images/sonywh1000xm5.jpg', 1, 1, 0, NULL),
(N'Apple Watch Ultra 2', N'Premium titanium smartwatch.', 19990000, N'https://example.com/images/watchultra2.jpg', 1, 1, 1, DATEADD(DAY, 5, GETDATE())),
(N'MacBook Air M3', N'Lightweight laptop with Apple Silicon chip.', 28990000, N'https://example.com/images/macbookm3.jpg', 1, 1, 0, NULL),
(N'GoPro Hero 12 Black', N'Action camera, 5.3K recording.', 11990000, N'https://example.com/images/gopro12.jpg', 1, 1, 0, NULL),
(N'Canon EOS R8', N'Full-frame mirrorless camera.', 32500000, N'https://example.com/images/canonr8.jpg', 1, 1, 0, NULL),
(N'LG OLED C4 55 inch', N'4K OLED TV, smart AI.', 25900000, N'https://example.com/images/lgc4.jpg', 1, 1, 1, DATEADD(DAY, 10, GETDATE())),
(N'Anker Power Bank 20000mAh', N'Fast charging portable battery.', 1200000, N'https://example.com/images/ankerpowerbank.jpg', 1, 1, 0, NULL),
(N'Logitech MX Master 3S', N'Wireless ergonomic mouse.', 2490000, N'https://example.com/images/mxmaster3s.jpg', 1, 1, 0, NULL),

-- CATEGORY 2: Fashion
(N'Nike Air Force 1', N'Classic white sneakers.', 2500000, N'https://example.com/images/airforce1.jpg', 2, 1, 0, NULL),
(N'Adidas Ultraboost 24', N'Performance running shoes.', 3200000, N'https://example.com/images/ultraboost.jpg', 2, 1, 0, NULL),
(N'Levi’s 511 Slim Jeans', N'Blue denim, slim fit.', 1800000, N'https://example.com/images/levis511.jpg', 2, 1, 0, NULL),
(N'Gucci Leather Belt', N'Luxury men belt.', 9500000, N'https://example.com/images/guccibelt.jpg', 2, 1, 1, DATEADD(DAY, 4, GETDATE())),
(N'Louis Vuitton Handbag', N'High-end women handbag.', 32900000, N'https://example.com/images/lvbag.jpg', 2, 1, 1, DATEADD(DAY, 8, GETDATE())),
(N'Uniqlo Hoodie', N'Comfort cotton hoodie.', 690000, N'https://example.com/images/uniqlohoodie.jpg', 2, 1, 0, NULL),
(N'H&M Casual Shirt', N'Slim fit cotton shirt.', 590000, N'https://example.com/images/hmshirt.jpg', 2, 1, 0, NULL),
(N'Ray-Ban Aviator Sunglasses', N'Unisex eyewear.', 3500000, N'https://example.com/images/raybanaviator.jpg', 2, 1, 0, NULL),
(N'Zara Men Jacket', N'Stylish winter jacket.', 2500000, N'https://example.com/images/zarajacket.jpg', 2, 1, 0, NULL),
(N'Calvin Klein Perfume', N'Euphoria 100ml fragrance.', 1800000, N'https://example.com/images/ckperfume.jpg', 2, 1, 0, NULL),

-- CATEGORY 3: Home & Living
(N'Wooden Coffee Table', N'Oak wood, minimalist design.', 1800000, N'https://example.com/images/coffeetable.jpg', 3, 1, 0, NULL),
(N'Ceramic Vase', N'Handcrafted decor piece.', 350000, N'https://example.com/images/ceramicvase.jpg', 3, 1, 0, NULL),
(N'LED Ceiling Lamp', N'Energy saving warm light.', 900000, N'https://example.com/images/ceilinglamp.jpg', 3, 1, 0, NULL),
(N'Luxury Curtains', N'Velvet material for living room.', 1200000, N'https://example.com/images/curtains.jpg', 3, 1, 0, NULL),
(N'Dyson Vacuum Cleaner', N'Cordless V12 model.', 15900000, N'https://example.com/images/dysonv12.jpg', 3, 1, 1, DATEADD(DAY, 6, GETDATE())),
(N'Air Purifier Xiaomi Pro', N'Smart HEPA filter purifier.', 4200000, N'https://example.com/images/xiaomipro.jpg', 3, 1, 0, NULL),
(N'Wall Clock', N'Minimalist design, wood finish.', 350000, N'https://example.com/images/wallclock.jpg', 3, 1, 0, NULL),
(N'IKEA Bookshelf', N'5-tier wooden shelf.', 1100000, N'https://example.com/images/bookshelf.jpg', 3, 1, 0, NULL),
(N'Kitchen Knife Set', N'Stainless steel 6-piece set.', 590000, N'https://example.com/images/knifeset.jpg', 3, 1, 0, NULL),
(N'Philips Air Fryer XXL', N'Healthy oil-free cooking.', 3900000, N'https://example.com/images/philipsxxl.jpg', 3, 1, 0, NULL),

-- CATEGORY 4: Toys & Hobbies
(N'Lego Millennium Falcon', N'Collector’s edition.', 5500000, N'https://example.com/images/lego-falcon.jpg', 4, 1, 0, NULL),
(N'Hot Wheels Car Set', N'Pack of 10 cars.', 350000, N'https://example.com/images/hotwheels.jpg', 4, 1, 0, NULL),
(N'DJI Mini 3 Drone', N'Compact 4K drone.', 14500000, N'https://example.com/images/djimini3.jpg', 4, 1, 1, DATEADD(DAY, 9, GETDATE())),
(N'UNO Card Game', N'Classic family game.', 150000, N'https://example.com/images/uno.jpg', 4, 1, 0, NULL),
(N'LEGO Technic Car', N'Advanced vehicle model.', 4500000, N'https://example.com/images/legotechnic.jpg', 4, 1, 0, NULL),
(N'RC Monster Truck', N'High-speed offroad RC car.', 2200000, N'https://example.com/images/monstertruck.jpg', 4, 1, 0, NULL),
(N'Magic Kit for Kids', N'Simple magician starter kit.', 590000, N'https://example.com/images/magickit.jpg', 4, 1, 0, NULL),
(N'Puzzle 1000 Pieces', N'Beautiful landscape puzzle.', 280000, N'https://example.com/images/puzzle.jpg', 4, 1, 0, NULL),
(N'RC Train Set', N'Electric model train.', 2500000, N'https://example.com/images/trainset.jpg', 4, 1, 1, DATEADD(DAY, 7, GETDATE())),
(N'Action Figure Batman', N'12-inch collectible figure.', 650000, N'https://example.com/images/batmanfigure.jpg', 4, 1, 0, NULL),

-- CATEGORY 5: Automotive
(N'Mobil 1 Engine Oil 5W-30', N'Premium synthetic oil.', 900000, N'https://example.com/images/mobil1.jpg', 5, 1, 0, NULL),
(N'Car Vacuum Cleaner', N'Portable for car interior.', 350000, N'https://example.com/images/carvacuum.jpg', 5, 1, 0, NULL),
(N'Michelin Tire 205/55R16', N'All-season durable tire.', 2000000, N'https://example.com/images/michelintire.jpg', 5, 1, 0, NULL),
(N'LED Headlight Bulb', N'Bright energy-saving bulbs.', 650000, N'https://example.com/images/ledheadlight.jpg', 5, 1, 0, NULL),
(N'Car Battery 12V', N'Long-lasting AGM battery.', 2500000, N'https://example.com/images/carbattery.jpg', 5, 1, 1, DATEADD(DAY, 3, GETDATE())),
(N'Dash Cam 4K', N'Front and rear camera system.', 2800000, N'https://example.com/images/dashcam4k.jpg', 5, 1, 0, NULL),
(N'Car Wax Kit', N'Professional detailing wax.', 450000, N'https://example.com/images/carwax.jpg', 5, 1, 0, NULL),
(N'Windshield Wipers', N'Universal 24-inch pair.', 300000, N'https://example.com/images/wipers.jpg', 5, 1, 0, NULL),
(N'Brake Pad Set', N'High-quality ceramic pads.', 990000, N'https://example.com/images/brakepads.jpg', 5, 1, 0, NULL),
(N'Car Shampoo', N'pH-balanced car cleaner.', 280000, N'https://example.com/images/carshampoo.jpg', 5, 1, 0, NULL);

GO
USE [CloneEbayDB];
GO

-- CATEGORY 6: Beauty & Health
INSERT INTO [dbo].[Product]
([title], [description], [price], [images], [categoryId], [sellerId], [isAuction], [auctionEndTime])
VALUES
(N'L’Oreal Shampoo 400ml', N'Nourishing hair repair formula.', 180000, N'https://example.com/images/lorealshampoo.jpg', 6, 1, 0, NULL),
(N'Nivea Body Lotion', N'Softens and moisturizes skin.', 220000, N'https://example.com/images/nivealotion.jpg', 6, 1, 0, NULL),
(N'Maybelline Mascara', N'Long-lasting waterproof mascara.', 250000, N'https://example.com/images/maybellinemascara.jpg', 6, 1, 0, NULL),
(N'Innisfree Green Tea Cream', N'Korean natural moisturizer.', 490000, N'https://example.com/images/innisfreecream.jpg', 6, 1, 0, NULL),
(N'Laneige Lip Sleeping Mask', N'Popular overnight lip care.', 390000, N'https://example.com/images/laneigelipmask.jpg', 6, 1, 1, DATEADD(DAY, 4, GETDATE())),
(N'Clinique Foundation', N'Full coverage liquid foundation.', 980000, N'https://example.com/images/clinique.jpg', 6, 1, 0, NULL),
(N'Vichy Mineral 89 Serum', N'Lightweight daily booster.', 890000, N'https://example.com/images/vichyserum.jpg', 6, 1, 0, NULL),
(N'Foreo Luna Mini 3', N'Sonic facial cleansing device.', 2900000, N'https://example.com/images/foreoluna.jpg', 6, 1, 1, DATEADD(DAY, 8, GETDATE())),
(N'Revlon Hair Dryer', N'Compact travel size.', 650000, N'https://example.com/images/revlonhairdryer.jpg', 6, 1, 0, NULL),
(N'SK-II Facial Treatment Essence', N'Legendary Pitera skincare.', 3190000, N'https://example.com/images/skiiessence.jpg', 6, 1, 0, NULL),
(N'Garnier Micellar Water', N'Makeup remover 400ml.', 230000, N'https://example.com/images/garnier.jpg', 6, 1, 0, NULL),
(N'Colgate Optic White Toothpaste', N'Teeth whitening toothpaste.', 120000, N'https://example.com/images/colgateopticwhite.jpg', 6, 1, 0, NULL),
(N'Oral-B Electric Toothbrush', N'Rechargeable toothbrush.', 1250000, N'https://example.com/images/oralb.jpg', 6, 1, 1, DATEADD(DAY, 6, GETDATE())),
(N'Neutrogena Sunscreen SPF50', N'Oil-free sun protection.', 420000, N'https://example.com/images/neutrogenasunscreen.jpg', 6, 1, 0, NULL),
(N'Clinique Eye Cream', N'Reduces dark circles.', 850000, N'https://example.com/images/cliniqueeye.jpg', 6, 1, 0, NULL),

-- CATEGORY 7: Sports & Outdoors
(N'Adidas Football', N'Official size 5 training ball.', 450000, N'https://example.com/images/adidasball.jpg', 7, 1, 0, NULL),
(N'Yonex Badminton Racket', N'Carbon fiber lightweight racket.', 1250000, N'https://example.com/images/yonexracket.jpg', 7, 1, 0, NULL),
(N'Wilson Tennis Racket', N'Professional tennis racket.', 2400000, N'https://example.com/images/wilsontennis.jpg', 7, 1, 0, NULL),
(N'Decathlon Camping Tent', N'2-person waterproof tent.', 1600000, N'https://example.com/images/tent.jpg', 7, 1, 1, DATEADD(DAY, 7, GETDATE())),
(N'Nike Running Shorts', N'Lightweight dri-fit shorts.', 450000, N'https://example.com/images/nikeshorts.jpg', 7, 1, 0, NULL),
(N'Garmin Forerunner 265', N'Smart GPS running watch.', 8900000, N'https://example.com/images/garmin265.jpg', 7, 1, 0, NULL),
(N'Yoga Mat 10mm', N'High-density non-slip mat.', 320000, N'https://example.com/images/yogamat.jpg', 7, 1, 0, NULL),
(N'Bicycle Helmet', N'Adjustable with LED light.', 540000, N'https://example.com/images/helmet.jpg', 7, 1, 0, NULL),
(N'Reebok Gym Bag', N'Spacious travel duffel.', 790000, N'https://example.com/images/reebokbag.jpg', 7, 1, 0, NULL),
(N'Dumbbell Set 20kg', N'Adjustable chrome dumbbells.', 1750000, N'https://example.com/images/dumbbell.jpg', 7, 1, 0, NULL),
(N'Adidas Tracksuit', N'Men training wear.', 1800000, N'https://example.com/images/track.jpg', 7, 1, 0, NULL),
(N'Puma Running Shoes', N'Comfort cushioning shoes.', 2100000, N'https://example.com/images/pumarun.jpg', 7, 1, 0, NULL),
(N'Mountain Bike 26 inch', N'Aluminum frame, 21 speed.', 6200000, N'https://example.com/images/mountainbike.jpg', 7, 1, 1, DATEADD(DAY, 9, GETDATE())),
(N'Trekking Backpack 50L', N'Water-resistant hiking bag.', 1650000, N'https://example.com/images/backpack.jpg', 7, 1, 0, NULL),
(N'Kettlebell 12kg', N'Rubber coated gym equipment.', 800000, N'https://example.com/images/kettlebell.jpg', 7, 1, 0, NULL),

-- CATEGORY 8: Books & Stationery
(N'Atomic Habits', N'Bestseller self-improvement book.', 280000, N'https://example.com/images/atomichabits.jpg', 8, 1, 0, NULL),
(N'The Subtle Art of Not Giving a F*ck', N'Mark Manson classic.', 320000, N'https://example.com/images/subtleart.jpg', 8, 1, 0, NULL),
(N'Python Programming 101', N'Beginner guide to coding.', 480000, N'https://example.com/images/pythonbook.jpg', 8, 1, 0, NULL),
(N'Moleskine Notebook', N'Hardcover ruled journal.', 390000, N'https://example.com/images/moleskine.jpg', 8, 1, 0, NULL),
(N'Stabilo Marker Set', N'Highlighter pastel set.', 180000, N'https://example.com/images/stabilo.jpg', 8, 1, 0, NULL),
(N'Kindle Paperwhite 11th Gen', N'E-ink reader with 8GB.', 3300000, N'https://example.com/images/kindle.jpg', 8, 1, 1, DATEADD(DAY, 6, GETDATE())),
(N'Japanese Calligraphy Pen', N'Fine brush tip pen.', 250000, N'https://example.com/images/calligraphypen.jpg', 8, 1, 0, NULL),
(N'To Kill a Mockingbird', N'Harper Lee classic novel.', 270000, N'https://example.com/images/mockingbird.jpg', 8, 1, 0, NULL),
(N'Canvas Book Bag', N'Lightweight eco tote.', 160000, N'https://example.com/images/bookbag.jpg', 8, 1, 0, NULL),
(N'Ergonomic Study Lamp', N'LED desk lamp with dimmer.', 520000, N'https://example.com/images/studylamp.jpg', 8, 1, 0, NULL),
(N'Blue Gel Pen Set', N'Box of 10 smooth pens.', 85000, N'https://example.com/images/gelpens.jpg', 8, 1, 0, NULL),
(N'World Atlas 2025 Edition', N'Comprehensive world map.', 410000, N'https://example.com/images/worldatlas.jpg', 8, 1, 0, NULL),
(N'Notebook Refill Paper A5', N'Pack of 100 sheets.', 75000, N'https://example.com/images/refillpaper.jpg', 8, 1, 0, NULL),
(N'Art of War', N'Sun Tzu classic edition.', 190000, N'https://example.com/images/artofwar.jpg', 8, 1, 0, NULL),
(N'High-Quality Pencil Case', N'Multi-compartment PU case.', 120000, N'https://example.com/images/pencilcase.jpg', 8, 1, 0, NULL),

-- CATEGORY 9: Art & Collectibles
(N'Canvas Painting Sunset', N'Hand-painted wall decor.', 890000, N'https://example.com/images/sunsetpainting.jpg', 9, 1, 0, NULL),
(N'Acrylic Paint Set 24 Colors', N'Professional artist kit.', 420000, N'https://example.com/images/acrylicset.jpg', 9, 1, 0, NULL),
(N'Wood Frame 30x40cm', N'Natural oak photo frame.', 190000, N'https://example.com/images/frame.jpg', 9, 1, 0, NULL),
(N'Watercolor Brush Set', N'10 pieces soft hair brushes.', 250000, N'https://example.com/images/brushset.jpg', 9, 1, 0, NULL),
(N'Handmade Ceramic Sculpture', N'Artisan crafted decor.', 1200000, N'https://example.com/images/sculpture.jpg', 9, 1, 1, DATEADD(DAY, 8, GETDATE())),
(N'Vinyl Record Beatles', N'Original reissue album.', 950000, N'https://example.com/images/beatlesvinyl.jpg', 9, 1, 0, NULL),
(N'Art Easel Stand', N'Adjustable metal tripod.', 690000, N'https://example.com/images/easel.jpg', 9, 1, 0, NULL),
(N'Calligraphy Ink Bottle', N'Black ink 50ml.', 120000, N'https://example.com/images/inkbottle.jpg', 9, 1, 0, NULL),
(N'Photography Light Box', N'Portable photo studio box.', 990000, N'https://example.com/images/lightbox.jpg', 9, 1, 0, NULL),
(N'Poster Mona Lisa', N'High quality art print.', 290000, N'https://example.com/images/monalisa.jpg', 9, 1, 0, NULL),
(N'Handmade Pottery Bowl', N'Simple Japanese style.', 350000, N'https://example.com/images/potterybowl.jpg', 9, 1, 0, NULL),
(N'Origami Paper Pack', N'Set of 100 colorful sheets.', 120000, N'https://example.com/images/origami.jpg', 9, 1, 0, NULL),
(N'Mini Sculpture Marble', N'Classical Greek replica.', 880000, N'https://example.com/images/marblesculpture.jpg', 9, 1, 0, NULL),
(N'Art Display Frame A3', N'Black wooden frame.', 320000, N'https://example.com/images/artframe.jpg', 9, 1, 0, NULL),
(N'Artist Sketchbook', N'A4 spiral-bound drawing pad.', 250000, N'https://example.com/images/sketchbook.jpg', 9, 1, 0, NULL),

-- CATEGORY 10: Pets
(N'Pet Food Dog Adult 5kg', N'Premium dry dog food.', 520000, N'https://example.com/images/dogfood.jpg', 10, 1, 0, NULL),
(N'Cat Toy Feather Wand', N'Interactive cat toy.', 120000, N'https://example.com/images/cattoy.jpg', 10, 1, 0, NULL),
(N'Fish Tank 60L', N'Glass aquarium with filter.', 1300000, N'https://example.com/images/fishtank.jpg', 10, 1, 0, NULL),
(N'Dog Leash Nylon', N'Durable 1.5m leash.', 140000, N'https://example.com/images/dogleash.jpg', 10, 1, 0, NULL),
(N'Cat Scratching Post', N'Stable wooden structure.', 480000, N'https://example.com/images/scratchingpost.jpg', 10, 1, 0, NULL),
(N'Pet Shampoo Aloe Vera', N'Gentle formula for all pets.', 180000, N'https://example.com/images/petshampoo.jpg', 10, 1, 0, NULL),
(N'Hamster Wheel', N'Silent running wheel.', 160000, N'https://example.com/images/hamsterwheel.jpg', 10, 1, 0, NULL),
(N'Pet Carrier Bag', N'Foldable travel bag.', 350000, N'https://example.com/images/petcarrier.jpg', 10, 1, 0, NULL),
(N'Bird Cage Medium', N'Metal cage for small birds.', 780000, N'https://example.com/images/birdcage.jpg', 10, 1, 1, DATEADD(DAY, 7, GETDATE())),
(N'Cat Litter Box', N'Easy-clean enclosed design.', 540000, N'https://example.com/images/litterbox.jpg', 10, 1, 0, NULL),
(N'Dog Bed Plush', N'Soft large dog bed.', 650000, N'https://example.com/images/dogbed.jpg', 10, 1, 0, NULL),
(N'Pet Nail Clipper', N'Safe stainless tool.', 120000, N'https://example.com/images/nailclipper.jpg', 10, 1, 0, NULL),
(N'Fish Food Flakes 200g', N'Balanced nutrition.', 95000, N'https://example.com/images/fishfood.jpg', 10, 1, 0, NULL),
(N'Cat Water Fountain', N'Automatic circulating water.', 790000, N'https://example.com/images/waterfountain.jpg', 10, 1, 0, NULL),
(N'Pet Blanket Fleece', N'Warm and washable.', 230000, N'https://example.com/images/petblanket.jpg', 10, 1, 0, NULL);
GO
