SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

DROP SCHEMA IF EXISTS `rkcrm_prototype` ;
CREATE SCHEMA IF NOT EXISTS `rkcrm_prototype` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
USE `rkcrm_prototype` ;

-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_job_titles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_job_titles` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_job_titles` (
  `title_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`title_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_locations`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_locations` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_locations` (
  `location_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`location_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_roles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_roles` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_roles` (
  `role_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`role_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`users` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`users` (
  `user_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `user_name` VARCHAR(45) NOT NULL ,
  `first_name` VARCHAR(45) NOT NULL ,
  `last_name` VARCHAR(45) NOT NULL ,
  `email_address` VARCHAR(100) NULL ,
  `job_title_id` INT UNSIGNED NULL ,
  `location_id` INT UNSIGNED NULL ,
  `role_id` INT UNSIGNED NULL ,
  `show_reminders` TINYINT(1) NOT NULL DEFAULT 0 ,
  `receives_crossleads` TINYINT(1) NOT NULL DEFAULT 0 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`user_id`) ,
  INDEX `fk_user_job_title` (`job_title_id` ASC) ,
  INDEX `fk_user_loc` (`location_id` ASC) ,
  INDEX `fk_user_role` (`role_id` ASC) ,
  UNIQUE INDEX `user_name_UNIQUE` (`user_name` ASC) ,
  CONSTRAINT `fk_user_job_title`
    FOREIGN KEY (`job_title_id` )
    REFERENCES `rkcrm_prototype`.`ref_job_titles` (`title_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_user_loc`
    FOREIGN KEY (`location_id` )
    REFERENCES `rkcrm_prototype`.`ref_locations` (`location_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_user_role`
    FOREIGN KEY (`role_id` )
    REFERENCES `rkcrm_prototype`.`ref_roles` (`role_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_departments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_departments` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_departments` (
  `department_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `falcon_whs` INT NULL ,
  `is_profit_center` TINYINT(1) NOT NULL DEFAULT 0 ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`department_id`) ,
  INDEX `falcon_whs` USING BTREE (`falcon_whs` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_customer_types`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_customer_types` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_customer_types` (
  `type_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `description` VARCHAR(500) NULL ,
  `require_unique_name` TINYINT(1) NOT NULL DEFAULT 0 ,
  `default_company_name` TINYINT(1) NOT NULL DEFAULT 0 ,
  `default_project_name` TINYINT(1) NOT NULL DEFAULT 0 ,
  `show_general_notes` TINYINT(1) NOT NULL DEFAULT 0 ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`type_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`customers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`customers` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`customers` (
  `customer_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(150) NOT NULL ,
  `address` VARCHAR(255) NULL ,
  `city` VARCHAR(100) NULL ,
  `state` VARCHAR(45) NULL ,
  `zip_code` INT(5) UNSIGNED ZEROFILL NULL ,
  `apt_lot_ste` VARCHAR(45) NULL ,
  `type_id` INT UNSIGNED NULL ,
  `falcon_id` VARCHAR(10) NULL ,
  `terms_code` VARCHAR(10) NULL ,
  `first_sale` DATE NULL ,
  `last_sale` DATE NULL ,
  `tax_id_expiration` DATE NULL ,
  `creditcard_expiration` DATE NULL ,
  `cannot_cross_lead` TINYINT(1) NOT NULL DEFAULT 0 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`customer_id`) ,
  INDEX `fk_customer_type` (`type_id` ASC) ,
  INDEX `customer_name` USING HASH (`name` ASC) ,
  CONSTRAINT `fk_customer_type`
    FOREIGN KEY (`type_id` )
    REFERENCES `rkcrm_prototype`.`ref_customer_types` (`type_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_lead_sources`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_lead_sources` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_lead_sources` (
  `source_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `details_required` TINYINT(1) NOT NULL DEFAULT 0 ,
  `list_object` VARCHAR(100) NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 0 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`source_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`competitors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`competitors` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`competitors` (
  `competitor_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`competitor_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`link_customer_competitor`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`link_customer_competitor` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`link_customer_competitor` (
  `customer_id` INT UNSIGNED NOT NULL ,
  `competitor_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`customer_id`, `competitor_id`) ,
  INDEX `fk_customer_competitor` (`customer_id` ASC) ,
  INDEX `fk_competitor_customer` (`competitor_id` ASC) ,
  CONSTRAINT `fk_customer_competitor`
    FOREIGN KEY (`customer_id` )
    REFERENCES `rkcrm_prototype`.`customers` (`customer_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_competitor_customer`
    FOREIGN KEY (`competitor_id` )
    REFERENCES `rkcrm_prototype`.`competitors` (`competitor_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_phone_types`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_phone_types` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_phone_types` (
  `type_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `abbreviation` VARCHAR(5) NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`type_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`phone_numbers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`phone_numbers` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`phone_numbers` (
  `phone_number_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `phone_number` VARCHAR(10) NOT NULL ,
  `type_id` INT UNSIGNED NULL ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`phone_number_id`) ,
  INDEX `fk_phonenumber_type` (`type_id` ASC) ,
  UNIQUE INDEX `index_phonenumbers` USING HASH (`phone_number` ASC) ,
  CONSTRAINT `fk_phonenumber_type`
    FOREIGN KEY (`type_id` )
    REFERENCES `rkcrm_prototype`.`ref_phone_types` (`type_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`link_customer_phonenumbers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`link_customer_phonenumbers` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`link_customer_phonenumbers` (
  `customer_id` INT UNSIGNED NOT NULL ,
  `phone_number_id` INT UNSIGNED NOT NULL ,
  `duplicate_index` CHAR(1) NOT NULL DEFAULT 'a' ,
  PRIMARY KEY (`customer_id`, `phone_number_id`) ,
  INDEX `fk_customer_phone` (`customer_id` ASC) ,
  INDEX `fk_phone_customer` (`phone_number_id` ASC) ,
  CONSTRAINT `fk_customer_phone`
    FOREIGN KEY (`customer_id` )
    REFERENCES `rkcrm_prototype`.`customers` (`customer_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_phone_customer`
    FOREIGN KEY (`phone_number_id` )
    REFERENCES `rkcrm_prototype`.`phone_numbers` (`phone_number_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_customer_department`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_customer_department` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_customer_department` (
  `customer_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  `is_active` TINYINT(1) NOT NULL DEFAULT 1 ,
  `first_sale` DATE NULL ,
  `last_sale` DATE NULL ,
  PRIMARY KEY (`customer_id`, `department_id`) ,
  INDEX `fk_history_customer` (`customer_id` ASC) ,
  INDEX `fk_history_department` (`department_id` ASC) ,
  CONSTRAINT `fk_history_customer`
    FOREIGN KEY (`customer_id` )
    REFERENCES `rkcrm_prototype`.`customers` (`customer_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_history_department`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_zip_codes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_zip_codes` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_zip_codes` (
  `zip_code` INT(5) ZEROFILL UNSIGNED NOT NULL ,
  `city` VARCHAR(45) NOT NULL ,
  `state` VARCHAR(45) NOT NULL ,
  `state_abbreviation` VARCHAR(2) NULL ,
  `created` DATE NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATE NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`zip_code`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_user_departments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_user_departments` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_user_departments` (
  `user_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  `is_home` TINYINT(1) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`user_id`, `department_id`) ,
  INDEX `fk_user_department` (`user_id` ASC) ,
  INDEX `fk_department_user` (`department_id` ASC) ,
  CONSTRAINT `fk_user_department`
    FOREIGN KEY (`user_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_department_user`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_contact_titles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_contact_titles` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_contact_titles` (
  `title_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`title_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`contacts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`contacts` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`contacts` (
  `contact_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `customer_id` INT UNSIGNED NOT NULL ,
  `first_name` VARCHAR(100) NULL ,
  `last_name` VARCHAR(100) NULL ,
  `email_address` VARCHAR(100) NULL ,
  `title_id` INT UNSIGNED NULL ,
  `is_subscriber` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`contact_id`) ,
  INDEX `fk_contact_titles` (`title_id` ASC) ,
  INDEX `fk_contact_customer` (`customer_id` ASC) ,
  CONSTRAINT `fk_contact_titles`
    FOREIGN KEY (`title_id` )
    REFERENCES `rkcrm_prototype`.`ref_contact_titles` (`title_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_contact_customer`
    FOREIGN KEY (`customer_id` )
    REFERENCES `rkcrm_prototype`.`customers` (`customer_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`link_contact_phonenumbers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`link_contact_phonenumbers` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`link_contact_phonenumbers` (
  `contact_id` INT UNSIGNED NOT NULL ,
  `phone_number_id` INT UNSIGNED NOT NULL ,
  `extension` VARCHAR(10) NULL ,
  `duplicate_index` CHAR(1) NOT NULL DEFAULT 'a' ,
  `is_preferred` TINYINT(1) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`contact_id`, `phone_number_id`) ,
  INDEX `fk_contact_phone` (`contact_id` ASC) ,
  INDEX `fk_phone_contact` (`phone_number_id` ASC) ,
  CONSTRAINT `fk_contact_phone`
    FOREIGN KEY (`contact_id` )
    REFERENCES `rkcrm_prototype`.`contacts` (`contact_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_phone_contact`
    FOREIGN KEY (`phone_number_id` )
    REFERENCES `rkcrm_prototype`.`phone_numbers` (`phone_number_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`invoices`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`invoices` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`invoices` (
  `invoice_id` INT UNSIGNED NOT NULL ,
  `customer_id` INT UNSIGNED NULL ,
  `order_id` INT UNSIGNED NOT NULL ,
  `falcon_id` VARCHAR(10) NULL ,
  `phone_number1` VARCHAR(11) NULL ,
  `phone_number2` VARCHAR(11) NULL ,
  `falcon_whs` INT UNSIGNED NOT NULL ,
  `amount` DECIMAL(10,2) NOT NULL ,
  `gross_margin` DECIMAL(10,2) NOT NULL ,
  `invoiced` DATE NOT NULL ,
  `imported` DATE NOT NULL ,
  `sales_rep` VARCHAR(45) NOT NULL ,
  `sales_rep_intitials` VARCHAR(45) NOT NULL ,
  `entered_by` VARCHAR(45) NULL ,
  `entered_by_initials` VARCHAR(45) NULL ,
  `account_terms` VARCHAR(45) NULL ,
  `invoice_terms` VARCHAR(45) NULL ,
  PRIMARY KEY (`invoice_id`) ,
  INDEX `fk_customer_invoices` (`customer_id` ASC) ,
  INDEX `invoice_whs` USING BTREE (`falcon_whs` ASC) ,
  CONSTRAINT `fk_customer_invoices`
    FOREIGN KEY (`customer_id` )
    REFERENCES `rkcrm_prototype`.`customers` (`customer_id` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_project_types`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_project_types` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_project_types` (
  `type_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`type_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`projects`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`projects` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`projects` (
  `project_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `customer_id` INT UNSIGNED NOT NULL ,
  `name` VARCHAR(150) NOT NULL ,
  `address` VARCHAR(45) NULL ,
  `apt` VARCHAR(45) NULL ,
  `city` VARCHAR(45) NULL ,
  `zip_code` INT(5) NULL ,
  `type_id` INT UNSIGNED NULL ,
  `contact_id` INT UNSIGNED NULL ,
  `description` VARCHAR(255) NULL ,
  `is_archived` TINYINT(1) NOT NULL DEFAULT 0 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`project_id`) ,
  INDEX `fk_project_customer` (`customer_id` ASC) ,
  INDEX `fk_project_contact` (`contact_id` ASC) ,
  INDEX `fk_project_type` (`type_id` ASC) ,
  CONSTRAINT `fk_project_customer`
    FOREIGN KEY (`customer_id` )
    REFERENCES `rkcrm_prototype`.`customers` (`customer_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_project_contact`
    FOREIGN KEY (`contact_id` )
    REFERENCES `rkcrm_prototype`.`contacts` (`contact_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_project_type`
    FOREIGN KEY (`type_id` )
    REFERENCES `rkcrm_prototype`.`ref_project_types` (`type_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`link_project_project`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`link_project_project` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`link_project_project` (
  `link_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `project_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`link_id`, `project_id`) ,
  INDEX `fk_project_project` (`project_id` ASC) ,
  CONSTRAINT `fk_project_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `rkcrm_prototype`.`projects` (`project_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`tmp_second_ids`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`tmp_second_ids` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`tmp_second_ids` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `second_id` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_project_statuses`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_project_statuses` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_project_statuses` (
  `status_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`status_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_project_department`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_project_department` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_project_department` (
  `project_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  `scope` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `status` ENUM('Oustanding','Sold','Lost') NULL ,
  `units` INT UNSIGNED NOT NULL DEFAULT 1 ,
  `probability` DECIMAL(3,2) NOT NULL DEFAULT 0.00 ,
  `expected_ship` DATE NULL ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`scope`, `project_id`, `department_id`) ,
  INDEX `fk_project_department` (`project_id` ASC) ,
  INDEX `fk_department_project` (`department_id` ASC) ,
  CONSTRAINT `fk_project_department`
    FOREIGN KEY (`project_id` )
    REFERENCES `rkcrm_prototype`.`projects` (`project_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_department_project`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_contact_methods`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_contact_methods` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_contact_methods` (
  `method_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`method_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`quotes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`quotes` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`quotes` (
  `quote_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `project_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NULL ,
  `scope` INT UNSIGNED NOT NULL ,
  `name` VARCHAR(45) NOT NULL ,
  `amount` DECIMAL(10,2) NOT NULL ,
  `description` VARCHAR(150) NULL ,
  `sales_rep_id` INT UNSIGNED NULL ,
  `support_id` INT UNSIGNED NULL ,
  `method_id` INT UNSIGNED NULL ,
  `contact_id` INT UNSIGNED NULL ,
  `is_sold` TINYINT(1) NOT NULL DEFAULT 0 ,
  `is_archived` TINYINT(1) NOT NULL DEFAULT 0 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`quote_id`) ,
  INDEX `fk_quote_project` (`project_id` ASC) ,
  INDEX `fk_quote_department` (`department_id` ASC) ,
  INDEX `fk_quote_salesrep` (`sales_rep_id` ASC) ,
  INDEX `fk_quote_support` (`support_id` ASC) ,
  INDEX `fk_quote_contact` (`contact_id` ASC) ,
  INDEX `fk_quote_method` (`method_id` ASC) ,
  CONSTRAINT `fk_quote_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `rkcrm_prototype`.`projects` (`project_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_quote_department`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_quote_salesrep`
    FOREIGN KEY (`sales_rep_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_quote_support`
    FOREIGN KEY (`support_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_quote_contact`
    FOREIGN KEY (`contact_id` )
    REFERENCES `rkcrm_prototype`.`contacts` (`contact_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_quote_method`
    FOREIGN KEY (`method_id` )
    REFERENCES `rkcrm_prototype`.`ref_contact_methods` (`method_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_contact_purposes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_contact_purposes` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_contact_purposes` (
  `purpose_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`purpose_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`notes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`notes` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`notes` (
  `note_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `project_id` INT UNSIGNED NOT NULL ,
  `notes` VARCHAR(255) NULL ,
  `sales_rep_id` INT UNSIGNED NULL ,
  `support_id` INT UNSIGNED NULL ,
  `department_id` INT UNSIGNED NULL ,
  `method_id` INT UNSIGNED NULL ,
  `purpose_id` INT UNSIGNED NULL ,
  `contact_id` INT UNSIGNED NULL ,
  `next_follow_up` DATE NULL ,
  `completed` DATE NULL ,
  `is_archived` TINYINT(1) NOT NULL DEFAULT 0 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`note_id`) ,
  INDEX `fk_note_project` (`project_id` ASC) ,
  INDEX `fk_note_salesrep` (`sales_rep_id` ASC) ,
  INDEX `fk_note_support` (`support_id` ASC) ,
  INDEX `fk_note_department` (`department_id` ASC) ,
  INDEX `fk_note_method` (`method_id` ASC) ,
  INDEX `fk_note_contact` (`contact_id` ASC) ,
  INDEX `fk_note_purpose` (`purpose_id` ASC) ,
  CONSTRAINT `fk_note_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `rkcrm_prototype`.`projects` (`project_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_note_salesrep`
    FOREIGN KEY (`sales_rep_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_note_support`
    FOREIGN KEY (`support_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_note_department`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_note_method`
    FOREIGN KEY (`method_id` )
    REFERENCES `rkcrm_prototype`.`ref_contact_methods` (`method_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_note_contact`
    FOREIGN KEY (`contact_id` )
    REFERENCES `rkcrm_prototype`.`contacts` (`contact_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_note_purpose`
    FOREIGN KEY (`purpose_id` )
    REFERENCES `rkcrm_prototype`.`ref_contact_purposes` (`purpose_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_contact_department`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_contact_department` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_contact_department` (
  `contact_id` INT UNSIGNED NOT NULL ,
  `deparmtent_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`contact_id`, `deparmtent_id`) ,
  INDEX `fk_contact_department` (`contact_id` ASC) ,
  INDEX `fk_department_contact` (`deparmtent_id` ASC) ,
  CONSTRAINT `fk_contact_department`
    FOREIGN KEY (`contact_id` )
    REFERENCES `rkcrm_prototype`.`contacts` (`contact_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_department_contact`
    FOREIGN KEY (`deparmtent_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`cross_leads`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`cross_leads` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`cross_leads` (
  `lead_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `project_id` INT UNSIGNED NOT NULL ,
  `plan_id` INT NULL ,
  `customer_has_details` TINYINT(1) NOT NULL DEFAULT 0 ,
  `is_digital_available` TINYINT(1) NOT NULL DEFAULT 0 ,
  `is_paper_available` TINYINT(1) NOT NULL DEFAULT 0 ,
  `is_list_available` TINYINT(1) NOT NULL DEFAULT 0 ,
  `bid_due` DATE NULL ,
  `notes` VARCHAR(500) NULL ,
  `sent` DATETIME NOT NULL ,
  `sender_id` INT NOT NULL ,
  PRIMARY KEY (`lead_id`) ,
  INDEX `fk_crosslead_project` (`project_id` ASC) ,
  CONSTRAINT `fk_crosslead_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `rkcrm_prototype`.`projects` (`project_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_crosslead_customer`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_crosslead_customer` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_crosslead_customer` (
  `customer_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  `lead_id` INT UNSIGNED NOT NULL ,
  `validated` DATE NULL ,
  `never_expires` TINYINT(1) NOT NULL DEFAULT 0 ,
  `is_archived` TINYINT(1) NOT NULL DEFAULT 0 ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`customer_id`, `department_id`) ,
  INDEX `fk_customer_lead` (`customer_id` ASC) ,
  INDEX `fk_lead_customer` (`lead_id` ASC) ,
  INDEX `fk_lead_department2` (`department_id` ASC) ,
  CONSTRAINT `fk_customer_lead`
    FOREIGN KEY (`customer_id` )
    REFERENCES `rkcrm_prototype`.`customers` (`customer_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_lead_customer`
    FOREIGN KEY (`lead_id` )
    REFERENCES `rkcrm_prototype`.`cross_leads` (`lead_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_lead_department2`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_crosslead_department`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_crosslead_department` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_crosslead_department` (
  `lead_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  `owner_id` INT UNSIGNED NULL ,
  `plans_received` DATE NULL ,
  `expected_completion` DATE NULL ,
  `assigned` DATETIME NULL ,
  `assigner_id` INT NULL ,
  PRIMARY KEY (`lead_id`, `department_id`) ,
  INDEX `fk_lead_department` (`lead_id` ASC) ,
  INDEX `fk_department_lead` (`department_id` ASC) ,
  INDEX `fk_lead_owner` (`owner_id` ASC) ,
  CONSTRAINT `fk_lead_department`
    FOREIGN KEY (`lead_id` )
    REFERENCES `rkcrm_prototype`.`cross_leads` (`lead_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_department_lead`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_lead_owner`
    FOREIGN KEY (`owner_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_competitor_department`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_competitor_department` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_competitor_department` (
  `competitor_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  PRIMARY KEY (`competitor_id`, `department_id`) ,
  INDEX `fk_competitor_department` (`competitor_id` ASC) ,
  INDEX `fk_department_competitor` (`department_id` ASC) ,
  CONSTRAINT `fk_competitor_department`
    FOREIGN KEY (`competitor_id` )
    REFERENCES `rkcrm_prototype`.`competitors` (`competitor_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_department_competitor`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_lost_reasons`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_lost_reasons` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_lost_reasons` (
  `reason_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`reason_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`lost_project_reports`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`lost_project_reports` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`lost_project_reports` (
  `project_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  `scope` INT UNSIGNED NOT NULL ,
  `reason_id` INT UNSIGNED NOT NULL ,
  `reason_details` VARCHAR(255) NULL ,
  `competitor_id` INT UNSIGNED NULL ,
  `competitor_details` VARCHAR(150) NULL ,
  `comments` VARCHAR(255) NULL ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`project_id`, `department_id`, `scope`) ,
  INDEX `fk_lost_project` (`project_id` ASC) ,
  INDEX `fk_lost_department` (`department_id` ASC) ,
  INDEX `fk_lost_reason` (`reason_id` ASC) ,
  INDEX `fk_lost_competitor` (`competitor_id` ASC) ,
  CONSTRAINT `fk_lost_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `rkcrm_prototype`.`projects` (`project_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_lost_department`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_lost_reason`
    FOREIGN KEY (`reason_id` )
    REFERENCES `rkcrm_prototype`.`ref_lost_reasons` (`reason_id` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_lost_competitor`
    FOREIGN KEY (`competitor_id` )
    REFERENCES `rkcrm_prototype`.`competitors` (`competitor_id` )
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_import_errors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_import_errors` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_import_errors` (
  `error_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(150) NOT NULL ,
  `cause` VARCHAR(250) NULL ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT NOT NULL ,
  PRIMARY KEY (`error_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_invoice_errors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_invoice_errors` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_invoice_errors` (
  `error_id` INT UNSIGNED NOT NULL ,
  `invoice_id` INT UNSIGNED NOT NULL ,
  `resolved` DATE NULL ,
  PRIMARY KEY (`error_id`, `invoice_id`) ,
  INDEX `fk_error_invoice` (`error_id` ASC) ,
  INDEX `fk_invoice_error` (`invoice_id` ASC) ,
  CONSTRAINT `fk_error_invoice`
    FOREIGN KEY (`error_id` )
    REFERENCES `rkcrm_prototype`.`ref_import_errors` (`error_id` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_invoice_error`
    FOREIGN KEY (`invoice_id` )
    REFERENCES `rkcrm_prototype`.`invoices` (`invoice_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`ref_report_groups`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`ref_report_groups` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`ref_report_groups` (
  `group_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `is_available` TINYINT(1) NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`group_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`reports`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`reports` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`reports` (
  `report_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `group_id` INT UNSIGNED NULL ,
  `name` VARCHAR(45) NOT NULL ,
  `parameter_form` VARCHAR(45) NULL ,
  `is_available` TINYINT NOT NULL DEFAULT 1 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`report_id`) ,
  INDEX `fk_report_group` (`group_id` ASC) ,
  CONSTRAINT `fk_report_group`
    FOREIGN KEY (`group_id` )
    REFERENCES `rkcrm_prototype`.`ref_report_groups` (`group_id` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_reportgroup_role`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_reportgroup_role` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_reportgroup_role` (
  `group_id` INT UNSIGNED NOT NULL ,
  `role_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`group_id`, `role_id`) ,
  INDEX `fk_group_role` (`group_id` ASC) ,
  INDEX `fk_role_group` (`role_id` ASC) ,
  CONSTRAINT `fk_group_role`
    FOREIGN KEY (`group_id` )
    REFERENCES `rkcrm_prototype`.`ref_report_groups` (`group_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_role_group`
    FOREIGN KEY (`role_id` )
    REFERENCES `rkcrm_prototype`.`ref_roles` (`role_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_report_department`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_report_department` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_report_department` (
  `report_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`report_id`, `department_id`) ,
  INDEX `fk_report_department` (`report_id` ASC) ,
  INDEX `fk_department_report` (`department_id` ASC) ,
  CONSTRAINT `fk_report_department`
    FOREIGN KEY (`report_id` )
    REFERENCES `rkcrm_prototype`.`reports` (`report_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_department_report`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_report_role`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_report_role` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_report_role` (
  `report_id` INT UNSIGNED NOT NULL ,
  `role_id` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`report_id`, `role_id`) ,
  INDEX `fk_report_role` (`report_id` ASC) ,
  INDEX `fk_role_report` (`role_id` ASC) ,
  CONSTRAINT `fk_report_role`
    FOREIGN KEY (`report_id` )
    REFERENCES `rkcrm_prototype`.`reports` (`report_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_role_report`
    FOREIGN KEY (`role_id` )
    REFERENCES `rkcrm_prototype`.`ref_roles` (`role_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`stats_daily_invoicing`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`stats_daily_invoicing` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`stats_daily_invoicing` (
  `daily_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `department_id` INT UNSIGNED NOT NULL ,
  `invoice_date` DATE NOT NULL ,
  `sales_rep` VARCHAR(75) NOT NULL ,
  `total_amount` DECIMAL(10,2) NOT NULL ,
  `total_gross_margin` DECIMAL(10,2) NOT NULL ,
  `avg_per_customer` DECIMAL(10,2) NOT NULL ,
  `avg_per_invoice` DECIMAL(10,2) NOT NULL ,
  `active_customers` INT NOT NULL ,
  `new_customers` INT NOT NULL ,
  `invoices` INT NOT NULL ,
  PRIMARY KEY (`daily_id`) ,
  INDEX `fk_invoicing_department` (`department_id` ASC) ,
  CONSTRAINT `fk_invoicing_department`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`sys_change_log`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`sys_change_log` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`sys_change_log` (
  `change_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `table_name` VARCHAR(64) NOT NULL ,
  `record_key` VARCHAR(45) NOT NULL ,
  `column_name` VARCHAR(45) NOT NULL ,
  `old_value` VARCHAR(255) NULL ,
  `new_value` VARCHAR(255) NULL ,
  `changer_id` INT UNSIGNED NOT NULL ,
  `changed` DATETIME NOT NULL ,
  PRIMARY KEY (`change_id`) ,
  INDEX `fk_entry_user` (`changer_id` ASC) ,
  CONSTRAINT `fk_entry_user`
    FOREIGN KEY (`changer_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`log_similar_name`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`log_similar_name` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`log_similar_name` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `original_name` VARCHAR(150) NOT NULL ,
  `new_name` VARCHAR(150) NOT NULL DEFAULT '' ,
  `possible_matches` INT NOT NULL DEFAULT 0 ,
  `button_chosen` ENUM('Yes', 'No') NOT NULL ,
  `is_name_valid` TINYINT(1) NOT NULL DEFAULT 0 ,
  `updater_id` INT NOT NULL ,
  `updated` DATETIME NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`log_program_exceptions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`log_program_exceptions` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`log_program_exceptions` (
  `exception_id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `receiver_id` INT UNSIGNED NOT NULL ,
  `received` DATETIME NULL ,
  `version` VARCHAR(45) NULL ,
  `is_solved` TINYINT(1) NULL ,
  `solved` DATE NULL ,
  `message` VARCHAR(5000) NULL ,
  `target_site` VARCHAR(5000) NULL ,
  `stack_trace` VARCHAR(40000) NULL ,
  PRIMARY KEY (`exception_id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rkcrm_prototype`.`rel_customer_leadsources`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `rkcrm_prototype`.`rel_customer_leadsources` ;

CREATE  TABLE IF NOT EXISTS `rkcrm_prototype`.`rel_customer_leadsources` (
  `relation_id` INT NOT NULL AUTO_INCREMENT ,
  `customer_id` INT UNSIGNED NOT NULL ,
  `department_id` INT UNSIGNED NOT NULL ,
  `source_id` INT UNSIGNED NOT NULL ,
  `activated` DATETIME NOT NULL ,
  `details` VARCHAR(255) NULL ,
  `is_archived` TINYINT(1) NOT NULL DEFAULT 0 ,
  `created` DATETIME NOT NULL ,
  `creator_id` INT UNSIGNED NOT NULL ,
  `updated` DATETIME NOT NULL ,
  `updater_id` INT UNSIGNED NOT NULL ,
  INDEX `fk_customer_source` (`customer_id` ASC) ,
  INDEX `fk_source_customer` (`source_id` ASC) ,
  INDEX `fk_department_source` (`department_id` ASC) ,
  INDEX `fk_creator_source` (`creator_id` ASC) ,
  PRIMARY KEY (`relation_id`) ,
  INDEX `fk_updater_source` (`updater_id` ASC) ,
  CONSTRAINT `fk_customer_source`
    FOREIGN KEY (`customer_id` )
    REFERENCES `rkcrm_prototype`.`customers` (`customer_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_source_customer`
    FOREIGN KEY (`source_id` )
    REFERENCES `rkcrm_prototype`.`ref_lead_sources` (`source_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_department_source`
    FOREIGN KEY (`department_id` )
    REFERENCES `rkcrm_prototype`.`ref_departments` (`department_id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_creator_source`
    FOREIGN KEY (`creator_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
  CONSTRAINT `fk_updater_source`
    FOREIGN KEY (`updater_id` )
    REFERENCES `rkcrm_prototype`.`users` (`user_id` )
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Placeholder table for view `rkcrm_prototype`.`customer_lastsale`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rkcrm_prototype`.`customer_lastsale` (`customer_id` INT, `last_sale` INT);

-- -----------------------------------------------------
-- Placeholder table for view `rkcrm_prototype`.`customer_phone`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rkcrm_prototype`.`customer_phone` (`phone_number` INT, `DateEntered` INT, `CreatorID` INT, `LastUpdated` INT, `UpdaterID` INT);

-- -----------------------------------------------------
-- Placeholder table for view `rkcrm_prototype`.`customer_leadsources`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rkcrm_prototype`.`customer_leadsources` (`CustomerID` INT, `LeadSource` INT, `dept_id` INT, `LeadSourceDetail` INT, `DateEntered` INT, `CreatorID` INT);

-- -----------------------------------------------------
-- procedure sales_history
-- -----------------------------------------------------

USE `rkcrm_prototype`;
DROP procedure IF EXISTS `rkcrm_prototype`.`sales_history`;

DELIMITER $$
USE `rkcrm_prototype`$$
CREATE PROCEDURE `rkcrm_prototype`.`sales_history` (
IN p_customer_id INT)
BEGIN
SELECT i.`customer_id`, d.`department_id`, cd.`last_sale`, i.`amount`, i.`sales_rep`, i.`invoice_terms`,
(SELECT SUM(y.`amount`) FROM `invoices` y     WHERE y.`customer_id` = cd.`customer_id` AND y.`falcon_whs` = d.`falcon_whs` AND 
    y.`invoiced` >= CONVERT(CONCAT(YEAR(CURDATE()),"-01-01") USING latin1)) AS `ytd_sales`,
(SELECT SUM(y.`amount`) FROM `invoices` y     WHERE y.`customer_id` = cd.`customer_id` AND y.`falcon_whs` = d.`falcon_whs` AND 
    y.`invoiced` BETWEEN CONVERT(CONCAT(YEAR(CURDATE()) - 1,"-01-01") USING latin1) AND CONVERT(CONCAT(YEAR(CURDATE()),"-01-01") USING latin1)) AS `last_year_sales` 
FROM `invoices` i
JOIN `ref_departments` d ON i.`falcon_whs` = d.`falcon_whs`
JOIN `rel_customer_department` cd ON i.`customer_id` = cd.`customer_id` AND d.`department_id` = cd.`department_id` AND i.`invoiced` = cd.`last_sale`
WHERE i.`customer_id` = p_customer_id;
END
$$

DELIMITER ;
-- -----------------------------------------------------
-- procedure project_calculations
-- -----------------------------------------------------

USE `rkcrm_prototype`;
DROP procedure IF EXISTS `rkcrm_prototype`.`project_calculations`;

DELIMITER $$
USE `rkcrm_prototype`$$
CREATE PROCEDURE `rkcrm_prototype`.`project_calculations` (
IN p_project_id INT)
BEGIN
SELECT pd.`project_id`, pd.`department_id`, pd.`scope`, pd.`status_id`, pd.`units`, pd.`probability`, pd.`expected_ship`, 
MAX(n.`next_follow_up`) AS `next_follow_up`, SUM(DISTINCT q.`amount`) AS `total`, 
AVG(q.`amount`) AS `average`, (((AVG(q.`amount`) * pd.`probability`) / IF((COUNT(DISTINCT pr1.`project_id`) = 0), 1, COUNT(DISTINCT pr1.`project_id`))) * pd.`units`) AS `value`,
COUNT(DISTINCT q.`quote_id`) AS `quote_count`, 
IF((COUNT(DISTINCT pr1.`project_id`) = 0),1,COUNT(DISTINCT pr1.`project_id`)) AS `cust_count`, q.`sales_rep_id` 
FROM `rel_project_department` pd 
LEFT JOIN `quotes` q ON pd.`project_id` = q.`project_id` and pd.`department_id` = q.`department_id` AND 
    pd.`scope` = q.`scope` AND q.`is_archived` = 0 
LEFT JOIN `notes` n ON pd.`project_id` = n.`project_id` AND pd.`department_id` = n.`department_id` AND ISNULL(n.`completed`) AND 
    n.`is_archived` = 0 
LEFT JOIN `link_project_project` pr ON pd.`project_id` = pr.`project_id` 
LEFT JOIN `link_project_project` pr1 ON pr.`link_id` = pr1.`link_id`
WHERE pd.`project_id` = p_project_id
GROUP BY pd.`project_id`, pd.`department_id`;
END

$$

DELIMITER ;
-- -----------------------------------------------------
-- procedure report_MyCrossLeadAnalysis
-- -----------------------------------------------------

USE `rkcrm_prototype`;
DROP procedure IF EXISTS `rkcrm_prototype`.`report_MyCrossLeadAnalysis`;

DELIMITER $$
USE `rkcrm_prototype`$$
CREATE PROCEDURE `rkcrm_prototype`.`report_MyCrossLeadAnalysis` (
IN p_rep_id INT,
IN p_start DATETIME,
IN p_end DATETIME,
IN p_user VARCHAR(45))
BEGIN
SELECT CONCAT(s.`first_name`, ' ', s.`last_name`) AS `sales_rep`, cl.`sent` AS `received`, cd.`assigned`, cd.`plans_received` AS `PlansReceived`, 
cd.`expected_completion` AS `ExpectedCompletion`, p.`name` AS `project`, pt.`name` AS `Type`, cu.`name` AS `customer`, 
IFNULL(MIN(n.`created`), MIN(q.`created`)) AS `first_contact`, CONCAT(u.`first_name`, ' ', u.`last_name`) AS `sender`, 
TIME_TO_SEC(TIMEDIFF(IFNULL(MIN(n.`created`), MIN(q.`created`)), IF(cd.`assigned` IS NULL || IFNULL(MIN(n.`created`), MIN(q.`created`)) = cd.`assigned`, cl.`sent`, cd.`assigned`))) AS `time_diff`, 
p_user, p_start, p_end 
FROM `cross_leads` cl 
JOIN `users` u ON cl.`sender_id` = u.`user_id`
JOIN `rel_crosslead_department` cd ON cl.`lead_id` = cd.`lead_id`
JOIN `users` s ON cd.`owner_id` = s.`user_id`
JOIN `projects` p ON cl.`project_id` = p.`project_id`
JOIN `ref_project_types` pt ON p.`type_id` = pt.`type_id`
JOIN `customers` cu ON p.`customer_id` = cu.`customer_id`
LEFT JOIN `notes` n ON cl.`project_id` = n.`project_id` AND cd.`department_id` = n.`department_id`
LEFT JOIN `quotes` q ON cl.`project_id` = q.`project_id` AND cd.`department_id` = q.`department_id`
WHERE cd.`owner_id` = p_rep_id AND IFNULL(cd.`assigned`, cl.`sent`) >= p_start AND 
IFNULL(cd.`assigned`, cl.`sent`) < ADDDATE(p_end, 1)
GROUP BY cl.`lead_id`, cd.`department_id`;
END
$$

DELIMITER ;
-- -----------------------------------------------------
-- View `rkcrm_prototype`.`customer_lastsale`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `rkcrm_prototype`.`customer_lastsale` ;
DROP TABLE IF EXISTS `rkcrm_prototype`.`customer_lastsale`;
USE `rkcrm_prototype`;
CREATE  OR REPLACE VIEW `rkcrm_prototype`.`customer_lastsale` AS
select `c`.`customer_id` AS `customer_id`,max(`t`.`DateInvoiced`) AS `last_sale` 
from (`rkcrm_prototype`.`customers` `c` 
join `rkcrm`.`transactions` `t` on `c`.`customer_id` = `t`.`CustomerID`) 
group by `c`.`customer_id`;

-- -----------------------------------------------------
-- View `rkcrm_prototype`.`customer_phone`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `rkcrm_prototype`.`customer_phone` ;
DROP TABLE IF EXISTS `rkcrm_prototype`.`customer_phone`;
USE `rkcrm_prototype`;
CREATE  OR REPLACE VIEW `rkcrm_prototype`.`customer_phone` AS select `pn`.`phone_number` AS `phone_number`,`c`.`DateEntered` AS `DateEntered`,`c`.`CreatorID` AS `CreatorID`,`c`.`LastUpdated` AS `LastUpdated`,`c`.`UpdaterID` AS `UpdaterID` from (`rkcrm_prototype`.`phone_numbers` `pn` join `rkcrm`.`customers` `c` on((`pn`.`phone_number` = replace(`c`.`CompanyNumber`,'-','')))) group by `pn`.`phone_number` having (`c`.`LastUpdated` = min(`c`.`LastUpdated`))
;

-- -----------------------------------------------------
-- View `rkcrm_prototype`.`customer_leadsources`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `rkcrm_prototype`.`customer_leadsources` ;
DROP TABLE IF EXISTS `rkcrm_prototype`.`customer_leadsources`;
USE `rkcrm_prototype`;
CREATE  OR REPLACE VIEW `rkcrm_prototype`.`customer_leadsources` AS
SELECT c.`CustomerID`, c.`LeadSource`, n.`dept_id`, c.`LeadSourceDetail`, c.`DateEntered`, c.`CreatorID`
FROM `rkcrm_old`.`customers` c
LEFT JOIN `rkcrm_old`.`notes` n ON n.`customer_id` = c.`CustomerID`
WHERE NOT n.`dept_id` IS NULL
GROUP BY c.`CustomerID`, n.`dept_id`
UNION
SELECT c.`CustomerID`, c.`LeadSource`, d.`UserDepartmentID`, c.`LeadSourceDetail`, c.`DateEntered`, c.`CreatorID`
FROM `rkcrm_old`.`customers` c
LEFT JOIN `rkcrm_old`.`transactions` t ON t.`CustomerID` = c.`CustomerID`
JOIN `rkcrm_old`.`ref_user_dept` d ON t.`Department` = d.`falcon_whs`
WHERE NOT d.`UserDepartmentID` IS NULL
GROUP BY c.`CustomerID`, d.`UserDepartmentID`;
USE `rkcrm_prototype`;


-- ************************************************-- Populate Database-- ************************************************
-- Users BEGIN
-- ***********

-- Populate roles
INSERT INTO `ref_roles` (`role_id`, `name`, `is_available`, `created`, `creator_id`, `updated`, `updater_id`)
SELECT r.`UserRolesID`, r.`Role`, r.`is_available`, r.`created`, r.`created_by`, r.`updated`, r.`updated_by`
FROM `rkcrm_old`.`ref_user_roles` r;

-- Populate locations
INSERT INTO `ref_locations` (`location_id`, `name`, `is_available`, `created`, `creator_id`, `updated`, `updater_id`)
SELECT l.`location_id`, l.`location`, l.`is_available`, l.`created`, l.`created_by`, l.`updated`, l.`updated_by` 
FROM `rkcrm_old`.`ref_user_loc` l;

-- Populate job titles
INSERT INTO `ref_job_titles` (`title_id`, `name`, `is_available`, `created`, `creator_id`, `updated`, `updater_id`)
SELECT j.`title_id`, j.`title`, j.`is_available`, j.`created`, j.`created_by`, j.`updated`, j.`updated_by`
FROM `rkcrm_old`.`ref_user_job_titles` j;

-- Populate departments
INSERT INTO `ref_departments` (`department_id`, `name`, `falcon_whs`, `is_profit_center`, `is_available`, `created`, 
`creator_id`, `updated`, `updater_id`) SELECT d.`UserDepartmentID`, d.`Department`, d.`falcon_whs`, d.`is_Profit_Center`, 
d.`is_available`, d.`created`, d.`created_by`, d.`updated`, d.`updated_by` FROM `rkcrm_old`.`ref_user_dept` d;

-- Populate users
INSERT INTO `users` (`user_id`, `user_name`, `first_name`, `last_name`, `email_address`, `job_title_id`, 
`location_id`, `role_id`, `show_reminders`, `receives_crossleads`, `created`, `creator_id`, `updated`, 
`updater_id`) SELECT u.`UserID`, u.`UserName`, u.`FirstName`, u.`LastName`, u.`email_address`, 
u.`job_title`, u.`UserLocation`, u.`UserRole`, u.`ShowFollowUpList`, u.`receives_crossleads`, u.`created`, u.`created_by`, 
u.`updated`, u.`updated_by` FROM `rkcrm_old`.`users` u;

-- Populate user to department relationships
INSERT INTO `rel_user_departments` 
SELECT u.`UserID`, u.`UserDepartment`, 1 FROM `rkcrm_old`.`users` u;

-- ********
-- User END


-- Customers BEGIN
-- ***************

-- Populate customer types
INSERT INTO `ref_customer_types` (`type_id`, `name`, `description`, `require_unique_name`, `default_company_name`, 
`default_project_name`, `show_general_notes`, `is_available`, `created`, `creator_id`, 
`updated`, `updater_id`) SELECT ct.`type_id`, ct.`type`, ct.`description`, ct.`require_unique_name`, ct.`default_company_name`, 
ct.`default_project_name`, ct.`show_general_notes`, ct.`is_available`, ct.`created`, ct.`creator_id`, ct.`updated`, 
ct.`updater_id` FROM `rkcrm_old`.`ref_customer_types_new` ct;

-- Populate lead sources
INSERT INTO `ref_lead_sources` (`source_id`, `name`, `details_required`, `is_available`, `created`, `creator_id`, 
`updated`, `updater_id`) SELECT l.`SourceID`, l.`LeadSource`, l.`details_required`, l.`is_available`, l.`created`, 
l.`created_by`, l.`updated`, l.`updated_by` FROM `rkcrm_old`.`ref_lead_sources` l;

-- Populate zip codes
INSERT INTO `ref_zip_codes` SELECT * FROM `rkcrm_old`.`zip_codes`;

-- Fix Existing zip codes
UPDATE `rkcrm_old`.`customers` c SET c.`ZipcodeAddress` = NULL WHERE c.`ZipcodeAddress` = "";
UPDATE `rkcrm_old`.`customers` c SET c.`LeadSourceDetail` = NULL WHERE c.`LeadSourceDetail` = "";
UPDATE `rkcrm_old`.`customers` c SET c.`StreetNameAddress` = NULL WHERE c.`StreetNameAddress` = "";

-- Populate customers
INSERT INTO `customers` (`customer_id`, `name`, `address`, `city`, `state`, `zip_code`, `apt_lot_ste`, `type_id`,
`falcon_id`, `terms_code`, `first_sale`, `tax_id_expiration`, `creditcard_expiration`, `cannot_cross_lead`, `created`, 
`creator_id`, `updated`, `updater_id`) SELECT `CustomerID`, `CompanyName`, `StreetNameAddress`, `CityAddress`, 
`StateAddress`, `ZipcodeAddress`, `ApartmentAddress`, `CustomerType`, `FalconNumber`, `TermsCode`, `FirstSaleDate`, 
`TaxIDExpiration`, `CreditCardExpiration`, `cannot_cross_lead`, `DateEntered`, `CreatorID`, `LastUpdated`, `UpdaterID` 
FROM `rkcrm_old`.`customers`;

UPDATE `customers` c JOIN `customer_lastsale` cl ON c.`customer_id` = cl.`customer_id` SET c.`last_sale` = cl.`last_sale`;

DROP VIEW `customer_lastsale`;

-- Lead Sources
INSERT INTO `rel_customer_leadsources` (`customer_id`, `department_id`, `source_id`, `activated`, `details`, `created`, `creator_id`, `updated`, `updater_id`) 
SELECT c.`CustomerID` AS `customer_id`, d.`UserDepartmentID` AS `department_id`, 52 AS `source_id`, 
NOW(), NULL AS `details`, NOW() AS `created`, 53 AS `creator_id`, NOW() AS `updated`, 53 AS `updater_id`
FROM `rkcrm_old`.`customers` c, `rkcrm_old`.`ref_user_dept` d
WHERE d.`is_profit_center` = 1;

UPDATE `rel_customer_leadsources` cl 
    JOIN `rkcrm_prototype`.`customer_leadsources` l ON cl.`customer_id` = l.`CustomerID` AND cl.`department_id` = l.`dept_id`
SET cl.`source_id` = l.`LeadSource`, cl.`activated` = l.`DateEntered`, cl.`details` = l.`LeadSourceDetail`, cl.`created` = l.`DateEntered`, cl.`creator_id` = l.`CreatorID`,
cl.`updated` = NOW();

DROP VIEW `customer_leadsources`;

-- Populate lead sort details form
UPDATE `ref_lead_sources` l SET l.`list_object` = 'rkcrm.Objects.Customer.Lead_Source.Details_Forms.CustomerName'
    WHERE l.`source_id` = 31;
UPDATE `ref_lead_sources` l SET l.`list_object` = 'rkcrm.Objects.Customer.Lead_Source.Details_Forms.UserName', l.`details_required` = 1
    WHERE l.`source_id` = 32;
UPDATE `ref_lead_sources` l SET l.`list_object` = 'rkcrm.Objects.Customer.Lead_Source.Details_Forms.CompetitorName'
    WHERE l.`source_id` = 43;
UPDATE `ref_lead_sources` l SET l.`list_object` = 'rkcrm.Objects.Customer.Lead_Source.Details_Forms.DepartmentAndYear'
    WHERE l.`source_id` = 44;
UPDATE `ref_lead_sources` l SET l.`list_object` = 'rkcrm.Objects.Customer.Lead_Source.Details_Forms.CustomerName'
    WHERE l.`source_id` = 63;
UPDATE `ref_lead_sources` l SET l.`list_object` = 'rkcrm.Objects.Customer.Lead_Source.Details_Forms.CustomerName'
    WHERE l.`source_id` = 64;
    
-- ************
-- Customer END


-- Contacts BEGIN
-- **************

-- Populate contact titles
INSERT INTO `ref_contact_titles` SELECT ct.`TitleID`, ct.`Title`, ct.`is_available`, ct.`created`, ct.`created_by`, 
ct.`updated`, ct.`updated_by` FROM `rkcrm_old`.`ref_contact_titles` ct;

-- Populate contacts
INSERT INTO `contacts` SELECT c.`ContactID`, c.`CustomerID`, c.`ContactFirstName`, c.`ContactLastName`, 
IF(c.`EmailAddress` = "", NULL, c.`EmailAddress`) , IF(c.`ContactTitle` = 0, NULL, c.`ContactTitle`), 
NOT c.`isUnsubscribed`, c.`DateEntered`, c.`CreatorID`, c.`LastUpdated`, c.`UpdaterID` 
FROM `rkcrm_old`.`contacts` c;

-- ************
-- Contacts END


-- Phone Numbers BEGIN
-- *******************

-- Populate phone number types
INSERT INTO `ref_phone_types` (`type_id`, `name`, `abbreviation`, `is_available`, `created`, `creator_id`, `updated`, `updater_id`)
SELECT pt.`PhoneTypeID`, pt.`PhoneType`, pt.`abbreviation`, pt.`is_available`, pt.`created`, pt.`created_by`, pt.`updated`,
pt.`updated_by` FROM `rkcrm_old`.`ref_number_types` pt;

-- Populate phone numbers
INSERT INTO `phone_numbers` (`phone_number`, `created`, `creator_id`, `updated`, `updater_id`) 
(SELECT REPLACE(c.`CompanyNumber`, "-", "") AS `phone`, NOW(), 53, NOW() , 53 FROM `rkcrm_old`.`customers` c) 
UNION 
(SELECT REPLACE(c1.`FirstNumber`, "-", ""), NOW(), 53, NOW() , 53 FROM `rkcrm_old`.`contacts` c1 WHERE c1.`FirstNumber` IS NOT NULL AND NOT c1.`FirstNumber` = "") 
UNION 
(SELECT REPLACE(c2.`SecondNumber`, "-", ""), NOW(), 53, NOW() , 53 FROM `rkcrm_old`.`contacts` c2 WHERE c2.`SecondNumber` IS NOT NULL AND NOT c2.`SecondNumber` = "") 
UNION 
(SELECT REPLACE(c3.`ThirdNumber`, "-", ""), NOW(), 53, NOW() , 53 FROM `rkcrm_old`.`contacts` c3 WHERE c3.`ThirdNumber` IS NOT NULL AND NOT c3.`ThirdNumber` = "")
ORDER BY `phone`;

UPDATE `phone_numbers` pn JOIN `customer_phone` cp ON pn.`phone_number` = cp.`phone_number` 
SET pn.`type_id` = 6, pn.`created` = cp.`DateEntered`, pn.`creator_id` = cp.`CreatorID`, pn.`updated` = cp.`LastUpdated`,
pn.`updater_id` = cp.`UpdaterID`;

UPDATE `phone_numbers` pn JOIN `rkcrm_old`.`contacts` c ON pn.`phone_number` = REPLACE(c.`FirstNumber`, "-", "") AND NOT c.`FirstNumberLabel` = 0
SET pn.`type_id` = c.`FirstNumberLabel`, pn.`created` = c.`DateEntered`, pn.`creator_id` = c.`CreatorID`, 
pn.`updated` = c.`LastUpdated`, pn.`updater_id` = c.`UpdaterID`;

UPDATE `phone_numbers` pn JOIN `rkcrm_old`.`contacts` c ON pn.`phone_number` = REPLACE(c.`SecondNumber`, "-", "") AND NOT c.`SecondNumberLabel` = 0
SET pn.`type_id` = c.`SecondNumberLabel`, pn.`created` = c.`DateEntered`, pn.`creator_id` = c.`CreatorID`, 
pn.`updated` = c.`LastUpdated`, pn.`updater_id` = c.`UpdaterID`;

UPDATE `phone_numbers` pn JOIN `rkcrm_old`.`contacts` c ON pn.`phone_number` = REPLACE(c.`ThirdNumber`, "-", "") AND NOT c.`ThirdNumberLabel` = 0
SET pn.`type_id` = c.`ThirdNumberLabel`, pn.`created` = c.`DateEntered`, pn.`creator_id` = c.`CreatorID`,
pn.`updated` = c.`LastUpdated`, pn.`updater_id` = c.`UpdaterID`;

INSERT INTO `link_customer_phonenumbers`
(`customer_id`, `phone_number_id`, `duplicate_index`)
SELECT c.`CustomerID`, pn.`phone_number_id`, IF(c.`MultipleAccounts` = "z", 'a', c.`MultipleAccounts`) 
FROM `phone_numbers` pn JOIN `rkcrm_old`.`customers` c ON pn.`phone_number` = REPLACE(c.`CompanyNumber`, "-", "");

INSERT INTO `link_contact_phonenumbers`
(`contact_id`, `phone_number_id`, `extension`, `duplicate_index`, `is_preferred`)
SELECT c.`ContactID`, pn.`phone_number_id`, c.`FirstExtention`, IF(c.`FirstMultiAccount` = "z", 'a', c.`FirstMultiAccount`), 
IF(c.`NumberPriority` = 1, TRUE, FALSE)
FROM `phone_numbers` pn JOIN `rkcrm_old`.`contacts` c ON pn.`phone_number` = REPLACE(c.`FirstNumber`, "-", "");

INSERT IGNORE INTO `link_contact_phonenumbers`
(`contact_id`, `phone_number_id`, `extension`, `duplicate_index`, `is_preferred`)
SELECT c.`ContactID`, pn.`phone_number_id`, c.`SecondExtention`, IF(c.`SecondMultiAccount` = "z", 'a', c.`SecondMultiAccount`), 
IF(c.`NumberPriority` = 2, TRUE, FALSE) 
FROM `phone_numbers` pn JOIN `rkcrm_old`.`contacts` c ON pn.`phone_number` = REPLACE(c.`SecondNumber`, "-", "");

INSERT IGNORE INTO `link_contact_phonenumbers`
(`contact_id`, `phone_number_id`, `extension`, `duplicate_index`, `is_preferred`)
SELECT c.`ContactID`, pn.`phone_number_id`, c.`ThirdExtention`, IF(c.`ThirdMultiAccount` = "z", 'a', c.`ThirdMultiAccount`), 
IF(c.`NumberPriority` = 3, TRUE, FALSE)
FROM `phone_numbers` pn JOIN `rkcrm_old`.`contacts` c ON pn.`phone_number` = REPLACE(c.`ThirdNumber`, "-", "");

DROP VIEW `customer_phone`;

-- *****************
-- Phone Numbers END


-- Invoices BEGIN
-- **************

-- Fix the data on the transaction table
UPDATE `rkcrm_old`.`transactions` t SET t.`PhoneNumber1` = NULL WHERE t.`PhoneNumber1` = "" OR t.`PhoneNumber1` = "   -   -";
UPDATE `rkcrm_old`.`transactions` t SET t.`PhoneNumber2` = NULL WHERE t.`PhoneNumber2` = "" OR t.`PhoneNumber2` = "   -   -";

-- Populate invoices
INSERT INTO `invoices`
(`invoice_id`, `customer_id`, `order_id`, `falcon_id`, `phone_number1`, `phone_number2`, `falcon_whs`, `amount`, 
`gross_margin`, `invoiced`, `imported`, `sales_rep`, `sales_rep_intitials`, `entered_by`, `entered_by_initials`, 
`account_terms`, `invoice_terms`)
SELECT t.`InvoiceNumber`, t.`CustomerID`, t.`OrderNumber`, t.`CustomerNumber`, REPLACE(t.`PhoneNumber1`, "-", ""), 
REPLACE(t.`PhoneNumber2`, "-", ""), t.`Department`, t.`TotalMerch`, t.`gross_margin`, t.`DateInvoiced`, 
t.`DateImported`, t.`SalesRep`, t.`SalesRepInitial`, t.`EnteredBy`, t.`EnteredByInitial`, t.`ACCTTerms`, t.`INVTerms` 
FROM `rkcrm_old`.`transactions` t;

INSERT INTO `invoices` SELECT e.`invoice_number`, NULL, e.`order_number`, e.`cust_number`, 
REPLACE(e.`phone_number`, "-", ""), REPLACE(e.`ship_to_number`, "-", ""), e.`whs`, e.`total_merch`, e.`gross_margin`, 
e.`date_invoiced`, e.`import_date`, e.`sales_rep`, e.`sales_rep_initial`, e.`entered_by`, e.`entered_by_initial`, 
e.`acct_terms`, e.`inv_terms`
FROM `rkcrm_old`.`import_errors` e;

-- Populate Sales History
INSERT INTO `rel_customer_department` (`customer_id`, `department_id`) 
SELECT c.`customer_id`, d.`department_id` FROM `customers` c, `ref_departments` d WHERE d.`is_profit_center` = 1;

UPDATE `rel_customer_department` cd SET cd.`last_sale` = (SELECT MAX(i.`invoiced`) AS `last_sale`
FROM `invoices` i 
JOIN `ref_departments` d ON i.`falcon_whs` = d.`falcon_whs`
WHERE i.`customer_id` = cd.`customer_id` AND d.`department_id` = cd.`department_id`
GROUP BY i.`customer_id`, i.`falcon_whs`);

UPDATE `rel_customer_department` sh JOIN `rkcrm_old`.`customers` c ON c.`CustomerID` = sh.`customer_id` 
SET sh.`is_active` = NOT c.`deactivated_door`
WHERE sh.`department_id` = 4;

UPDATE `rel_customer_department` sh JOIN `rkcrm_old`.`customers` c ON c.`CustomerID` = sh.`customer_id` 
SET sh.`is_active` = NOT c.`deactivated_insulation`
WHERE sh.`department_id` = 5;

UPDATE `rel_customer_department` sh JOIN `rkcrm_old`.`customers` c ON c.`CustomerID` = sh.`customer_id` 
SET sh.`is_active` = NOT c.`deactivated_lumber`
WHERE sh.`department_id` = 6;

UPDATE `rel_customer_department` sh JOIN `rkcrm_old`.`customers` c ON c.`CustomerID` = sh.`customer_id` 
SET sh.`is_active` = NOT c.`deactivated_truss`
WHERE sh.`department_id` = 7;

UPDATE `rel_customer_department` sh JOIN `rkcrm_old`.`customers` c ON c.`CustomerID` = sh.`customer_id` 
SET sh.`is_active` = NOT c.`deactivated_window`
WHERE sh.`department_id` = 8;

UPDATE `rel_customer_department` cd 
SET cd.`first_sale` = 
(SELECT MIN(i.`invoiced`) 
FROM `invoices` i JOIN `ref_departments` d ON i.`falcon_whs` = d.`falcon_whs` 
WHERE i.`customer_id` = cd.`customer_id` AND d.`department_id` = cd.`department_id`);

-- ************
-- Invoices END


-- Projects BEGIN
-- **************

-- Propulate the tmp second ids table
INSERT INTO `tmp_second_ids` (`second_id`) 
SELECT p.`second_id` FROM `rkcrm_old`.`projects` p WHERE NOT p.`project_id` = p.`second_id` AND NOT p.`second_id` = 0
GROUP BY p.`second_id`; 

-- Populate project types
INSERT INTO `ref_project_types`
(`type_id`, `name`, `is_available`, `created`, `creator_id`, `updated`, `updater_id`) 
SELECT pt.`ProjectTypeID`, pt.`Type`, pt.`is_available`, pt.`created`, pt.`created_by`, pt.`updated`, pt.`updated_by`
FROM `rkcrm_old`.`ref_project_types` pt;

-- Projects table fixes
UPDATE `rkcrm_old`.`projects` p LEFT JOIN `rkcrm_old`.`contacts` co ON p.`contact_id` = co.`ContactID`
SET p.`contact_id` = 0 WHERE co.`ContactFirstName` IS NULL;

UPDATE `rkcrm_old`.`projects` p SET p.`zip_code` = NULL WHERE p.`zip_code` = "";

-- Populate Projects
INSERT INTO `projects` SELECT p.`project_id`, p.`customer_id`, p.`name`, p.`address`, p.`apt`, p.`city`, p.`zip_code`, 
p.`type_id`, IF(p.`contact_id` = 0, NULL, p.`contact_id`), NULL, p.`is_archived`, p.`created`, p.`creator_id`, 
p.`updated`, p.`updater_id` FROM `rkcrm_old`.`projects` p;

-- Populate project relationships
INSERT INTO `link_project_project` SELECT t.`id`, p.`project_id` 
FROM `rkcrm_old`.`projects` p JOIN `tmp_second_ids` t ON p.`second_id` = t.`second_id` ORDER BY t.`id`;

-- Drop Temp table
DROP TABLE `tmp_second_ids`;

-- Populate project statuses
INSERT INTO `ref_project_statuses` SELECT `StatusID`, `Status`, `is_available` FROM `rkcrm_old`.`ref_project_status`;

-- Populate project-department relationship table
INSERT IGNORE INTO `rel_project_department` SELECT pc.`proj_id`, pc.`dept_id`, (pc.`scope` + 1) AS `scope`, pc.`status_id`, 
pc.`units`, pc.`probability`, pc.`exp_ship`, pc.`created`, pc.`salesrep_id`, pc.`updated`, pc.`salesrep_id` 
FROM `rkcrm_old`.`project_calculations` pc;

-- ************
-- Projects END


-- Quotes BEGIN
-- ************

-- Populate contact methods
INSERT INTO `ref_contact_methods` SELECT * FROM `rkcrm_old`.`ref_contact_methods`;

-- Populate Quotes
INSERT INTO `quotes` SELECT q.`quote_id`, q.`project_id`, q.`dept_id`, (q.`scope` + 1), q.`name`, q.`amount`, 
q.`description`, q.`salesrep_id`, q.`support_id`, q.`method_id`, q.`contact_id`, q.`is_sold`, q.`is_archived`, q.`created`, 
q.`creator_id`, q.`updated`, q.`updater_id` FROM `rkcrm_old`.`quotes` q;

-- **********
-- Quotes END


-- Notes BEGIN
-- ***********

-- Populate contact purposes
INSERT INTO `ref_contact_purposes` SELECT p.`PurposeID`, p.`Purpose`, p.`is_available`, p.`created`, p.`created_by`, 
p.`updated`, p.`updated_by` FROM `rkcrm_old`.`ref_purposes` p;

-- Populate Notes
INSERT INTO `notes` SELECT n.`note_id`, n.`project_id`, n.`notes`, n.`salesrep_id`, n.`support_id`, n.`dept_id`, 
n.`method_id`, n.`purpose_id`, n.`contact_id`, n.`next_follow_up`, n.`followed_up`, n.`is_archived`, n.`created`, 
n.`creator_id`, n.`updated`, n.`updater_id` FROM `rkcrm_old`.`notes` n;

-- *********
-- Notes END


-- Cross Leads BEGIN
-- *****************

INSERT INTO `cross_leads` SELECT * FROM `rkcrm_old`.`cross_leads` cl;

INSERT INTO `rel_crosslead_department` SELECT cd.`lead_id`, cd.`department_id`, cd.`AssignedTo`, cd.`PlansReceived`, 
cd.`ExpectedCompletion`, cd.`Assigned`, cd.`AssignedBy` FROM `rkcrm_old`.`rel_crosslead_dept` cd;

INSERT INTO `rel_crosslead_customer` SELECT cs.`customer_id`, cs.`department_id`, cl.`lead_id`, cs.`validated`, 
cs.`never_expires`, cs.`is_archived`, cs.`updated`, cs.`updater_id`
FROM `rkcrm_old`.`cross_sales` cs
JOIN `rkcrm_old`.`projects` p ON cs.`customer_id` = p.`customer_id`
JOIN `rkcrm_old`.`cross_leads` cl ON p.`project_id` = cl.`project_id` AND cs.`sales_rep_id` = cl.`creator_id`
LEFT JOIN `rkcrm_old`.`rel_crosslead_dept` cd ON cl.`lead_id` = cd.`lead_id` AND cd.`department_id` = cs.`department_id`
WHERE cs.`is_archived` = 0
GROUP BY cs.`customer_id`, cs.`department_id`;

-- ***************
-- Cross Leads END


-- Competitors BEGIN
-- *****************

INSERT INTO `competitors` 
SELECT c.`competitor_id`, c.`name`, 1, c.`created`, c.`created_by`, c.`updated`, c.`updated_by` 
FROM `rkcrm_old`.`ref_competitors` c;

INSERT INTO `rel_competitor_department` 
SELECT cd.`competitor_id`, cd.`department_id`, cd.`is_available` FROM `rkcrm_old`.`rel_competitor_dept` cd;

UPDATE `rkcrm_old`.`customers` c SET c.`PreviousVendor` = NULL WHERE c.`PreviousVendor` = "";
UPDATE `rkcrm_old`.`customers` c SET c.`PreviousVendor` = REPLACE(c.`PreviousVendor`, ",", ";") WHERE c.`PreviousVendor` IS NOT NULL;
UPDATE `rkcrm_old`.`customers` c SET c.`PreviousVendor` = REPLACE(c.`PreviousVendor`, "\\", "; ") WHERE c.`PreviousVendor` IS NOT NULL;
UPDATE `rkcrm_old`.`customers` c SET c.`PreviousVendor` = REPLACE(c.`PreviousVendor`, "/", "; ") WHERE c.`PreviousVendor` IS NOT NULL;

INSERT INTO `link_customer_competitor`
SELECT c.`CustomerID`, co.`competitor_id`
FROM `rkcrm_old`.`customers` c
JOIN `competitors` co ON co.`name` LIKE CONCAT("%", c.`PreviousVendor`, "%") OR c.`PreviousVendor` LIKE CONCAT("%", co.`name`, "%");

-- ***************
-- Competitors END


-- Lost Projects BEGIN
-- *******************

INSERT INTO `ref_lost_reasons` SELECT * FROM `rkcrm_old`.`ref_lost_reasons`;

INSERT INTO `lost_project_reports` SELECT l.`project_id`, l.`dept_id`, l.`scope`, IFNULL(l.`reason_id`, 9), IF(l.`reason_details` = "", NULL, l.`reason_details`), 
l.`competitor_id`, IF(l.`competitor_name` = "", NULL, l.`competitor_name`), IF(l.`comments` = "", NULL, l.`comments`), 
IFNULL(l.`created`, q.`updated`), q.`sales_rep_id`, IFNULL(l.`created`, q.`updated`), q.`sales_rep_id`
FROM `rkcrm_old`.`lost_sale_reports` l
JOIN `quotes` q ON l.`project_id` = q.`project_id` AND q.`department_id` = l.`dept_id` AND q.`scope` = (l.`scope` + 1)
GROUP BY l.`project_id`, l.`dept_id`, l.`scope`;

-- *****************
-- Lost Projects END


-- Import Errors BEGIN
-- *******************

INSERT INTO `ref_import_errors` SELECT e.`error_type_id`, e.`error_type`, e.`cause`, e.`created`, e.`created_by`, 
e.`updated`, e.`updated_by` FROM `rkcrm_old`.`ref_import_error_types` e;

INSERT INTO `rel_invoice_errors` SELECT e.`error_type_id`, e.`invoice_number`, t.`DateImported`
FROM `rkcrm_old`.`import_error_log` e
LEFT JOIN `rkcrm_old`.`transactions` t ON t.`InvoiceNumber` = e.`invoice_number`
GROUP BY e.`error_type_id`, e.`invoice_number`;

-- *****************
-- Import Errors END


-- Reports BEGIN
-- *************

INSERT INTO `ref_report_groups` (`group_id`, `name`, `created`, `creator_id`, `updated`, `updater_id`) 
SELECT * FROM `rkcrm_old`.`report_groups`;

INSERT INTO `reports` (`report_id`, `name`, `parameter_form`, `created`, `creator_id` ,`updated` ,`updater_id` , `group_id`)
SELECT r.*, rg.`group_id` FROM `rkcrm_old`.`reports` r
LEFT JOIN `rkcrm_old`.`rel_reportgroups_reports` rg ON rg.`report_id` = r.`report_id`;

INSERT INTO `rel_report_department` 
SELECT rd.`report_id`, rd.`department_id` FROM `rkcrm_old`.`rel_report_dept` rd;

INSERT INTO `rel_reportgroup_role` 
SELECT rr.`group_id`, rr.`role_id` FROM `rkcrm_old`.`rel_reportgroups_roles` rr;

INSERT INTO `rel_report_role`
SELECT rr.`report_id`, rr.`role_id` FROM `rkcrm_old`.`rel_report_role` rr;

-- ***********
-- Reports END


-- Daily Invoicing BEGIN
-- *********************

INSERT INTO `stats_daily_invoicing` SELECT b.`CurrentBusinessID`, d.`department_id`, b.`InvoicedDate`, b.`SalesRep`, 
b.`InvoicedTotal`, b.`GrossMarginSum`, b.`AVGSalesPerCustomer`, b.`AVGSalesPerInvoice`, b.`ActiveCustomers`, 
b.`NewCustomers`, b.`NumberOfSales`
FROM `rkcrm_old`.`stats_daily_current_business` b
JOIN `ref_departments` d ON b.`Department` = d.`name`;

-- *******************
-- Daily Invoicing END


-- ************************************************
-- Populate Database END
-- ************************************************


DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`customer_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `customer_insert_log`
AFTER INSERT ON `customers`
FOR EACH ROW
BEGIN

IF NOT NEW.`name` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'name', NULL, NEW.`name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`address` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'address', NULL, NEW.`address`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`zip_code` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'zip_code', NULL, NEW.`zip_code`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`apt_lot_ste` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'apt_lot_ste', NULL, NEW.`apt_lot_ste`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`type_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'type_id', NULL, NEW.`type_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`tax_id_expiration` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'tax_id_expiration', NULL, NEW.`tax_id_expiration`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`creditcard_expiration` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'creditcard_expiration', NULL, NEW.`creditcard_expiration`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`cannot_cross_lead` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'cannot_cross_lead', NULL, NEW.`cannot_cross_lead`,
    NEW.`updater_id`, NOW());
END IF;

#Create a GENERAL NOTES project for each customer created
INSERT INTO `projects` SET
`customer_id` = NEW.`customer_id`,
`name` = 'GENERAL NOTES',
`type_id` = 10,
`is_archived` = NOT (SELECT ct.`require_unique_name` FROM `ref_customer_types` ct WHERE ct.`type_id` = NEW.`type_id`),
`created` = NOW(),
`creator_id` = NEW.`creator_id`,
`updated` = NOW(),
`updater_id` = NEW.`updater_id`;

INSERT INTO `rel_customer_department` (`customer_id`, `department_id`)
SELECT c.`customer_id`, d.`department_id`
FROM `customers` c, `ref_departments` d
WHERE c.`customer_id` = NEW.`customer_id` AND d.`is_profit_center` = 1;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`customer_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `customer_update_log`
AFTER UPDATE ON `customers`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`name`, "") = IFNULL(NEW.`name`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'name', OLD.`name`, NEW.`name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`address`, "") = IFNULL(NEW.`address`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'address', OLD.`address`, NEW.`address`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`zip_code`, "") = IFNULL(NEW.`zip_code`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'zip_code', OLD.`zip_code`, NEW.`zip_code`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`apt_lot_ste`, "") = IFNULL(NEW.`apt_lot_ste`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'apt_lot_ste', OLD.`apt_lot_ste`, NEW.`apt_lot_ste`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`type_id`, "") = IFNULL(NEW.`type_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'type_id', OLD.`type_id`, NEW.`type_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`tax_id_expiration`, "") = IFNULL(NEW.`tax_id_expiration`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'tax_id_expiration', OLD.`tax_id_expiration`, NEW.`tax_id_expiration`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`creditcard_expiration`, "") = IFNULL(NEW.`creditcard_expiration`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'creditcard_expiration', OLD.`creditcard_expiration`, NEW.`creditcard_expiration`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`cannot_cross_lead`, "") = IFNULL(NEW.`cannot_cross_lead`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('customers', NEW.`customer_id`, 'cannot_cross_lead', OLD.`cannot_cross_lead`, NEW.`cannot_cross_lead`,
    NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`competitor_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `competitor_insert_log`
AFTER INSERT ON `competitors`
FOR EACH ROW
BEGIN

IF NOT NEW.`name` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('competitors', NEW.`competitor_id`, 'name', NULL, NEW.`name`,
    NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`competitor_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `competitor_update_log`
AFTER UPDATE ON `competitors`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`name`, "") = IFNULL(NEW.`name`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('competitors', NEW.`competitor_id`, 'name', OLD.`name`, NEW.`name`,
    NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`phone_number_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `phone_number_insert_log`
AFTER INSERT ON `phone_numbers`
FOR EACH ROW
BEGIN

IF NOT NEW.`phone_number` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('phone_numbers', NEW.`phone_number_id`, 'phone_number', NULL, NEW.`phone_number`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`type_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('phone_numbers', NEW.`phone_number_id`, 'type_id', NULL, NEW.`type_id`,
    NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`phone_number_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `phone_number_update_log`
AFTER UPDATE ON `phone_numbers`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`phone_number`, "") = IFNULL(NEW.`phone_number`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('phone_numbers', NEW.`phone_number_id`, 'phone_number', OLD.`phone_number`, NEW.`phone_number`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`type_id`, "") = IFNULL(NEW.`type_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('phone_numbers', NEW.`phone_number_id`, 'type_id', OLD.`type_id`, NEW.`type_id`,
    NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`link_customer_phonenumber_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `link_customer_phonenumber_insert_log`
AFTER INSERT ON `link_customer_phonenumbers`
FOR EACH ROW
BEGIN

SET @Updater = (SELECT p.`updater_id` FROM `phone_numbers` p WHERE p.`phone_number_id` = NEW.`phone_number_id`);

IF NOT NEW.`duplicate_index` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('link_customer_phonenumbers', CONCAT(NEW.`customer_id`, '-', NEW.`phone_number_id`), 'duplicate_index', NULL, NEW.`duplicate_index`,
    @Updater, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`link_customer_phonenumber_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `link_customer_phonenumber_update_log`
AFTER UPDATE ON `link_customer_phonenumbers`
FOR EACH ROW
BEGIN

SET @Updater = (SELECT p.`updater_id` FROM `phone_numbers` p WHERE p.`phone_number_id` = NEW.`phone_number_id`);

IF NOT IFNULL(OLD.`duplicate_index`, "") = IFNULL(NEW.`duplicate_index`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('link_customer_phonenumbers', CONCAT(NEW.`customer_id`, '-', NEW.`phone_number_id`), 'duplicate_index', OLD.`duplicate_index`, NEW.`duplicate_index`,
    @Updater, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`rel_customer_department_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rel_customer_department_update_log`
AFTER UPDATE ON `rel_customer_department`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`is_active`, "") = IFNULL(NEW.`is_active`, "") THEN
    SET @Updater = (SELECT c.`updater_id` FROM `customers` c WHERE c.`customer_id` = NEW.`customer_id`);
    
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_customer_department', CONCAT(NEW.`customer_id`, '-', NEW.`department_id`), 'is_active', OLD.`is_active`, NEW.`is_active`,
    @Updater, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`contact_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `contact_insert_log`
AFTER INSERT ON `contacts`
FOR EACH ROW
BEGIN

IF NOT NEW.`first_name` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'first_name', NULL, NEW.`first_name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`last_name` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'last_name', NULL, NEW.`last_name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`email_address` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'email_address', NULL, NEW.`email_address`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`title_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'title_id', NULL, NEW.`title_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`is_subscriber` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'is_subscriber', NULL, NEW.`is_subscriber`,
    NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`contact_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `contact_update_log`
AFTER UPDATE ON `contacts`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`first_name`, "") = IFNULL(NEW.`first_name`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'first_name', OLD.`first_name`, NEW.`first_name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`last_name`, "") = IFNULL(NEW.`last_name`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'last_name', OLD.`last_name`, NEW.`last_name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`email_address`, "") = IFNULL(NEW.`email_address`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'email_address', OLD.`email_address`, NEW.`email_address`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`title_id`, "") = IFNULL(NEW.`title_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'title_id', OLD.`title_id`, NEW.`title_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT OLD.`is_subscriber` = NEW.`is_subscriber` THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('contacts', NEW.`contact_id`, 'is_subscriber', OLD.`is_subscriber`, NEW.`is_subscriber`,
    NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`link_contact_phonenumber_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `link_contact_phonenumber_insert_log`
AFTER INSERT ON `link_contact_phonenumbers`
FOR EACH ROW
BEGIN

SET @Updater = (SELECT p.`updater_id` FROM `phone_numbers` p WHERE p.`phoneNumber_id` = NEW.`phone_number_id`);

IF NOT NEW.`extension` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('link_contact_phonenumbers', CONCAT(NEW.`contact_id`, '-', NEW.`phone_number_id`), 'extension', NULL, NEW.`extension`,
    @Updater, NOW());
END IF;

IF NOT NEW.`duplicate_index` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('link_contact_phonenumbers', CONCAT(NEW.`contact_id`, '-', NEW.`phone_number_id`), 'duplicate_index', NULL, NEW.`duplicate_index`,
    @Updater, NOW());
END IF;

IF NOT NEW.`is_preferred` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('link_contact_phonenumbers', CONCAT(NEW.`contact_id`, '-', NEW.`phone_number_id`), 'is_preferred', NULL, NEW.`is_preferred`,
    @Updater, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`link_contact_phonenumber_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `link_contact_phonenumber_update_log`
AFTER UPDATE ON `link_contact_phonenumbers`
FOR EACH ROW
BEGIN

SET @Updater = (SELECT p.`updater_id` FROM `phone_numbers` p WHERE p.`phoneNumber_id` = NEW.`phone_number_id`);

IF NOT IFNULL(OLD.`extension`, "") = IFNULL(NEW.`extension`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('link_contact_phonenumbers', CONCAT(NEW.`contact_id`, '-', NEW.`phone_number_id`), 'extension', OLD.`extension`, NEW.`extension`,
    @Updater, NOW());
END IF;

IF NOT IFNULL(OLD.`duplicate_index`, "") = IFNULL(NEW.`duplicate_index`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('link_contact_phonenumbers', CONCAT(NEW.`contact_id`, '-', NEW.`phone_number_id`), 'duplicate_index', OLD.`duplicate_index`, NEW.`duplicate_index`,
    @Updater, NOW());
END IF;

IF NOT IFNULL(OLD.`is_preferred`, "") = IFNULL(NEW.`is_preferred`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('link_contact_phonenumbers', CONCAT(NEW.`contact_id`, '-', NEW.`phone_number_id`), 'is_preferred', OLD.`is_peferred`, NEW.`is_preferred`,
    @Updater, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`project_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `project_insert_log`
AFTER INSERT ON `projects`
FOR EACH ROW
BEGIN

IF NOT NEW.`name` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('projects', NEW.`project_id`, 'name', NULL, NEW.`name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`address` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('projects', NEW.`project_id`, 'address', NULL, NEW.`address`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`apt` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('projects', NEW.`project_id`, 'apt', NULL, NEW.`apt`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`zip_code` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('projects', NEW.`project_id`, 'zip_code', NULL, NEW.`zip_code`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`type_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('projects', NEW.`project_id`, 'type_id', NULL, NEW.`type_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`contact_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('projects', NEW.`project_id`, 'contact_id', NULL, NEW.`contact_id`,
    NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`project_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `project_update_log`
AFTER UPDATE ON `projects`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`name`, "") = IFNULL(NEW.`name`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('projects', NEW.`project_id`, 'name', OLD.`name`, NEW.`name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`address`, "") = IFNULL(NEW.`address`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('projects', NEW.`project_id`, 'address', OLD.`address`, NEW.`address`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`apt`, "") = IFNULL(NEW.`apt`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('projects', NEW.`project_id`, 'apt', OLD.`apt`, NEW.`apt`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`zip_code`, "") = IFNULL(NEW.`zip_code`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('projects', NEW.`project_id`, 'zip_code', OLD.`zip_code`, NEW.`zip_code`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`type_id`, "") = IFNULL(NEW.`type_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('projects', NEW.`project_id`, 'type_id', OLD.`type_id`, NEW.`type_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`contact_id`, "") = IFNULL(NEW.`contact_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('projects', NEW.`project_id`, 'contact_id', OLD.`contact_id`, NEW.`contact_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`is_archived`, "") = IFNULL(NEW.`is_archived`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('projects', NEW.`project_id`, 'is_archived', OLD.`is_archived`, NEW.`is_archived`,
    NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`rel_project_department_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rel_project_department_insert_log`
AFTER INSERT ON `rel_project_department`
FOR EACH ROW
BEGIN

IF NOT NEW.`status` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_project_department', CONCAT(NEW.`project_id`, '-', NEW.`department_id`, '-', NEW.`scope`), 
    'status', NULL, NEW.`status`, NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`units` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_project_department', CONCAT(NEW.`project_id`, '-', NEW.`department_id`, '-', NEW.`scope`), 
    'units', NULL, NEW.`units`, NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`probability` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_project_department', CONCAT(NEW.`project_id`, '-', NEW.`department_id`, '-', NEW.`scope`), 
    'probability', NULL, NEW.`probability`, NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`expected_ship` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_project_department', CONCAT(NEW.`project_id`, '-', NEW.`department_id`, '-', NEW.`scope`), 
    'expected_ship', NULL, NEW.`expected_ship`, NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`rel_project_department_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rel_project_department_update_log`
AFTER UPDATE ON `rel_project_department`
FOR EACH ROW
BEGIN

SET @QuoteUpdater = (SELECT q.`updater_id` FROM `quotes` q WHERE q.`project_id` = NEW.`project_id` ORDER BY q.`updated` DESC LIMIT 1);

IF NOT IFNULL(OLD.`status`, "") = IFNULL(NEW.`status`, "") THEN
    SET @ProjectUpdater = (SELECT p.`updater_id` FROM `projects` p WHERE p.`project_id` = NEW.`project_id`);

    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_project_department', CONCAT(NEW.`project_id`, '-', NEW.`department_id`, '-', NEW.`scope`), 
    'status', OLD.`status`, NEW.`status`, NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`units`, "") = IFNULL(NEW.`units`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_project_department', CONCAT(NEW.`project_id`, '-', NEW.`department_id`, '-', NEW.`scope`), 
    'units', OLD.`units`, NEW.`units`, NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`probability`, "") = IFNULL(NEW.`probability`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_project_department', CONCAT(NEW.`project_id`, '-', NEW.`department_id`, '-', NEW.`scope`), 
    'probability', OLD.`probability`, NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`expected_ship`, "") = IFNULL(NEW.`expected_ship`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_project_department', CONCAT(NEW.`project_id`, '-', NEW.`department_id`, '-', NEW.`scope`), 
    'expected_ship', OLD.`expected_ship`, NEW.`expected_ship`, NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`quote_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `quote_insert_log`
AFTER INSERT ON `quotes`
FOR EACH ROW
BEGIN

IF NOT NEW.`department_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('quotes', NEW.`quote_id`, 'department_id', NULL, NEW.`department_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`name` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('quotes', NEW.`quote_id`, 'name', NULL, NEW.`name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`amount` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('quotes', NEW.`quote_id`, 'amount', NULL, NEW.`amount`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`description` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('quotes', NEW.`quote_id`, 'description', NULL, NEW.`description`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`sales_rep_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('quotes', NEW.`quote_id`, 'sales_rep_id', NULL, NEW.`sales_rep_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`support_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('quotes', NEW.`quote_id`, 'support_id', NULL, NEW.`support_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`method_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('quotes', NEW.`quote_id`, 'method_id', NULL, NEW.`method_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`contact_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('quotes', NEW.`quote_id`, 'contact_id', NULL, NEW.`contact_id`,
    NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`quote_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `quote_update_log`
AFTER UPDATE ON `quotes`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`department_id`, "") = IFNULL(NEW.`department_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'department_id', OLD.`department_id`, NEW.`department_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`name`, "") = IFNULL(NEW.`name`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'name', OLD.`name`, NEW.`name`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`amount`, "") = IFNULL(NEW.`amount`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'amount', OLD.`amount`, NEW.`amount`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`description`, "") = IFNULL(NEW.`description`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'description', OLD.`description`, NEW.`description`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`sales_rep_id`, "") = IFNULL(NEW.`sales_rep_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'sales_rep_id', OLD.`sales_rep_id`, NEW.`sales_rep_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`support_id`, "") = IFNULL(NEW.`support_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'support_id', OLD.`support_id`, NEW.`support_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`method_id`, "") = IFNULL(NEW.`method_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'method_id', OLD.`method_id`, NEW.`method_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`contact_id`, "") = IFNULL(NEW.`contact_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'contact_id', OLD.`contact_id`, NEW.`contact_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`is_sold`, "") = IFNULL(NEW.`is_sold`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'is_sold', OLD.`is_sold`, NEW.`is_sold`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`is_archived`, "") = IFNULL(NEW.`is_archived`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('quotes', NEW.`quote_id`, 'is_archived', OLD.`is_archived`, NEW.`is_archived`,
    NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`note_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `note_insert_log`
AFTER INSERT ON `notes`
FOR EACH ROW
BEGIN

IF NOT NEW.`notes` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('notes', NEW.`note_id`, 'notes', NULL, NEW.`notes`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`sales_rep_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('notes', NEW.`note_id`, 'sales_rep_id', NULL, NEW.`sales_rep_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`support_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('notes', NEW.`note_id`, 'support_id', NULL, NEW.`support_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`department_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('notes', NEW.`note_id`, 'department_id', NULL, NEW.`department_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`method_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('notes', NEW.`note_id`, 'method_id', NULL, NEW.`method_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`purpose_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('notes', NEW.`note_id`, 'purpose_id', NULL, NEW.`purpose_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`contact_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('notes', NEW.`note_id`, 'contact_id', NULL, NEW.`contact_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`next_follow_up` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('notes', NEW.`note_id`, 'next_follow_up', NULL, NEW.`next_follow_up`,
    NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`note_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `note_update_log`
AFTER UPDATE ON `notes`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`notes`, "") = IFNULL(NEW.`notes`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'notes', OLD.`notes`, NEW.`notes`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`sales_rep_id`, "") = IFNULL(NEW.`sales_rep_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'sales_rep_id', OLD.`sales_rep_id`, NEW.`sales_rep_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`support_id`, "") = IFNULL(NEW.`support_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'support_id', OLD.`support_id`, NEW.`support_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`department_id`, "") = IFNULL(NEW.`department_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'department_id', OLD.`department_id`, NEW.`department_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`method_id`, "") = IFNULL(NEW.`method_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'method_id', OLD.`method_id`, NEW.`method_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`purpose_id`, "") = IFNULL(NEW.`purpose_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'purpose_id', OLD.`purpose_id`, NEW.`purpose_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`contact_id`, "") = IFNULL(NEW.`contact_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'contact_id', OLD.`contact_id`, NEW.`contact_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`next_follow_up`, "") = IFNULL(NEW.`next_follow_up`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'next_follow_up', OLD.`next_follow_up`, NEW.`next_follow_up`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`completed`, "") = IFNULL(NEW.`completed`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'completed', OLD.`completed`, NEW.`completed`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`is_archived`, "") = IFNULL(NEW.`is_archived`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('notes', NEW.`note_id`, 'is_archived', OLD.`is_archived`, NEW.`is_archived`,
    NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`rel_crosslead_customer_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rel_crosslead_customer_insert_log`
AFTER INSERT ON `rel_crosslead_customer`
FOR EACH ROW
BEGIN

IF NOT NEW.`validated` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_crosslead_customer', CONCAT(NEW.`customer_id`, '-', NEW.`department_id`), 'validated', NULL, NEW.`validated`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`never_expires` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_crosslead_customer', CONCAT(NEW.`customer_id`, '-', NEW.`department_id`), 'never_expires', NULL, NEW.`never_expires`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`is_archived` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_crosslead_customer', CONCAT(NEW.`customer_id`, '-', NEW.`department_id`), 'is_archived', NULL, NEW.`is_archived`,
    NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`rel_crosslead_customer_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rel_crosslead_customer_update_log`
AFTER UPDATE ON `rel_crosslead_customer`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`validated`, "") = IFNULL(NEW.`validated`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_crosslead_customer', CONCAT(NEW.`customer_id`, '-', NEW.`department_id`), 'validated', OLD.`validated`, NEW.`validated`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`never_expires`, "") = IFNULL(NEW.`never_expires`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_crosslead_customer', CONCAT(NEW.`customer_id`, '-', NEW.`department_id`), 'never_expires', OLD.`never_expires`, NEW.`never_expires`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`is_archived`, "") = IFNULL(NEW.`is_archived`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_crosslead_customer', CONCAT(NEW.`customer_id`, '-', NEW.`department_id`), 'is_archived', OLD.`is_archived`, NEW.`is_archived`,
    NEW.`updater_id`, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`rel_crosslead_department_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rel_crosslead_department_insert_log`
AFTER INSERT ON `rel_crosslead_department`
FOR EACH ROW
BEGIN

SET @Updater = (SELECT l.`sender_id` FROM `cross_leads` l WHERE l.`lead_id` = NEW.`lead_id`);

IF NOT NEW.`owner_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'owner_id', NULL, NEW.`owner_id`,
    @Updater, NOW());
END IF;

IF NOT NEW.`plans_received` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'plans_received', NULL, NEW.`plans_received`,
    @Updater, NOW());
END IF;

IF NOT NEW.`expected_completion` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'expected_completion', NULL, NEW.`expected_completion`,
    @Updater, NOW());
END IF;

IF NOT NEW.`assigned` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'assigned', NULL, NEW.`assigned`,
    @Updater, NOW());
END IF;

IF NOT NEW.`assigner_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`)
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'assigner_id', NULL, NEW.`assigner_id`,
    @Updater, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`rel_crosslead_department_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rel_crosslead_department_update_log`
AFTER UPDATE ON `rel_crosslead_department`
FOR EACH ROW
BEGIN

SET @Updater = (SELECT l.`sender_id` FROM `cross_leads` l WHERE l.`lead_id` = NEW.`lead_id`);

IF NOT IFNULL(OLD.`owner_id`, "") = IFNULL(NEW.`owner_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'owner_id', OLD.`owner_id`, NEW.`owner_id`,
    @Updater, NOW());
END IF;

IF NOT IFNULL(OLD.`plans_received`, "") = IFNULL(NEW.`plans_received`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'plans_received', OLD.`plans_received`, NEW.`plans_received`,
    @Updater, NOW());
END IF;

IF NOT IFNULL(OLD.`expected_completion`, "") = IFNULL(NEW.`expected_completion`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'expected_completion', OLD.`expected_completion`, NEW.`expected_completion`,
    @Updater, NOW());
END IF;

IF NOT IFNULL(OLD.`assigned`, "") = IFNULL(NEW.`assigned`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'assigned', OLD.`assigned`, NEW.`assigned`,
    @Updater, NOW());
END IF;

IF NOT IFNULL(OLD.`assigner_id`, "") = IFNULL(NEW.`assigner_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_crosslead_department', CONCAT(NEW.`lead_id`, '-', NEW.`department_id`), 'assigner_id', OLD.`assigner_id`, NEW.`assigner_id`,
    @Updater, NOW());
END IF;

END $$


DELIMITER ;

DELIMITER $$

USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`customer_leadsource_insert_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rkcrm_prototype`.`customer_leadsource_insert_log`
AFTER INSERT ON `rkcrm_prototype`.`rel_customer_leadsources`
FOR EACH ROW
BEGIN

IF NOT NEW.`customer_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) VALUES ('rel_customer_leadsources', NEW.`relation_id`, 
    'customer_id', NULL, NEW.`customer_id`, NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`department_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) VALUES ('rel_customer_leadsources', NEW.`relation_id`, 
    'department_id', NULL, NEW.`department_id`, NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`source_id` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) VALUES ('rel_customer_leadsources', NEW.`relation_id`, 
    'source_id', NULL, NEW.`source_id`, NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`activated` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) VALUES ('rel_customer_leadsources', NEW.`relation_id`, 
    'activated', NULL, NEW.`activated`, NEW.`updater_id`, NOW());
END IF;

IF NOT NEW.`details` IS NULL THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) VALUES ('rel_customer_leadsources', NEW.`relation_id`, 
    'details', NULL, NEW.`details`, NEW.`updater_id`, NOW());
END IF;

END$$


USE `rkcrm_prototype`$$
DROP TRIGGER IF EXISTS `rkcrm_prototype`.`customer_leadsource_update_log` $$
USE `rkcrm_prototype`$$


CREATE
DEFINER=`root`@`%`
TRIGGER `rkcrm_prototype`.`customer_leadsource_update_log`
AFTER UPDATE ON `rkcrm_prototype`.`rel_customer_leadsources`
FOR EACH ROW
BEGIN

IF NOT IFNULL(OLD.`customer_id`, "") = IFNULL(NEW.`customer_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_customer_leadsources', NEW.`relation_id`, 'customer_id', OLD.`customer_id`, NEW.`customer_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`department_id`, "") = IFNULL(NEW.`department_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_customer_leadsources', NEW.`relation_id`, 'department_id', OLD.`department_id`, NEW.`department_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`source_id`, "") = IFNULL(NEW.`source_id`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_customer_leadsources', NEW.`relation_id`, 'source_id', OLD.`source_id`, NEW.`source_id`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`activated`, "") = IFNULL(NEW.`activated`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_customer_leadsources', NEW.`relation_id`, 'activated', OLD.`activated`, NEW.`activated`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`details`, "") = IFNULL(NEW.`details`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_customer_leadsources', NEW.`relation_id`, 'details', OLD.`details`, NEW.`details`,
    NEW.`updater_id`, NOW());
END IF;

IF NOT IFNULL(OLD.`is_archived`, "") = IFNULL(NEW.`is_archived`, "") THEN
    INSERT INTO `sys_change_log` (`table_name`, `record_key`, `column_name`, `old_value`,
    `new_value`, `changer_id`, `changed`) 
    VALUES ('rel_customer_leadsources', NEW.`relation_id`, 'is_archived', OLD.`is_archived`, NEW.`is_archived`,
    NEW.`updater_id`, NOW());
END IF;

END$$


DELIMITER ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
