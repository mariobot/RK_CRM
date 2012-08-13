SELECT l.*, (SELECT l2.`created` 
              FROM `rel_customer_leadsources` l2 
              WHERE l2.`customer_id` = l.`customer_id` AND l2.`department_id` = l.`department_id` AND l2.`created` > l.`created` 
              ORDER BY l2.`department_id`, l2.`created` ASC LIMIT 1) AS `end`
FROM `rel_customer_leadsources` l WHERE l.`customer_id` = 4861 ORDER BY l.`department_id`, l.`created` DESC