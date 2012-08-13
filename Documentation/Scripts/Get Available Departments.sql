-- EDIT `rkcrm_prototype`.`cross_leads`;

SELECT d.`department_id`
FROM (`ref_departments` d, `projects` p)
LEFT JOIN `rel_project_department` pd ON p.`project_id` = pd.`project_id` AND d.`department_id` = pd.`department_id`
LEFT JOIN `notes` n ON p.`project_id` = n.`project_id` AND d.`department_id` = n.`department_id` AND n.`is_archived` = 0
LEFT JOIN `quotes` q ON p.`project_id` = q.`project_id` AND d.`department_id` = q.`department_id` AND q.`is_archived` = 0
LEFT JOIN `cross_leads` cl ON p.`project_id` = cl.`project_id`
WHERE d.`is_profit_center` = 1 AND (pd.`status_id` = 1 OR pd.`status_id` IS NULL) AND p.`project_id` = 15632
GROUP BY d.`department_id`, p.`project_id`
HAVING COUNT(DISTINCT n.`note_id`) + COUNT(DISTINCT q.`quote_id`) + COUNT(DISTINCT cl.`lead_id`) = 0
