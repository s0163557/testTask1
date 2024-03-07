1. Сколько каждого материала должно уходить на каждый заказ? (итоговая сумма)
SELECT Idorder, SUM(qu) AS ИтоговаяСумма
FROM view_orderitem
GROUP BY Idorder;

2. Сколько всего материалов каких материалов должно уйти на все заказы? 
SELECT Good_marking, SUM(qustore * qu) AS ВсегоМатериала
FROM view_orderitem
LEFT JOIN view_modelcalc
ON view_modelcalc.Idorderitem = view_orderitem.Idorderitem
GROUP BY Good_marking;

3. Сколько и какого материала должно уйти на изделия Окно для продавца Иванова
SELECT Good_marking, SUM(qu * qustore) AS КоличествоМатериалаДляПродавца
FROM
(SELECT Iforderitem, qu
FROM view_orderitem, view_orders
WHERE view_orders.Idorder = view_orderitem.Idorder AND Seller_name='Иванов' AND view_orderitem.Name = 'Окно') AS sec1
LEFT JOIN view_modelcalc
ON sec1.Idorderitem = view_modelcalc.Idorderitem
GROUP BY Good_marking;
