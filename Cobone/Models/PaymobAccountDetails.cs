﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class PaymobAccountDetails
    {

        public PaymobProfile profile { get; set; }
        public string token { get; set; }
    }

    public class PaymobProfile
    {
        public int id { get; set; }
        public PaymobUser user { get; set; }
        public DateTime created_at { get; set; }
        public bool active { get; set; }
        public string profile_type { get; set; }
        public string[] phones { get; set; }
        public string[] company_emails { get; set; }
        public string company_name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string street { get; set; }
        public bool email_notification { get; set; }
        public object order_retrieval_endpoint { get; set; }
        public object delivery_update_endpoint { get; set; }
        public object logo_url { get; set; }
        public bool is_mobadra { get; set; }
        public string sector { get; set; }
        public int activation_method { get; set; }
        public int signed_up_through { get; set; }
        public int failed_attempts { get; set; }
        public object[] custom_export_columns { get; set; }
        public object[] server_IP { get; set; }
        public object username { get; set; }
        public object primary_phone_number { get; set; }
        public bool primary_phone_verified { get; set; }
        public bool is_temp_password { get; set; }
        public object otp_sent_at { get; set; }
        public object otp_sent_to { get; set; }
        public object otp_validated_at { get; set; }
        public object awb_banner { get; set; }
        public object email_banner { get; set; }
        public object identification_number { get; set; }
        public string delivery_status_callback { get; set; }
        public object merchant_external_link { get; set; }
        public int merchant_status { get; set; }
        public bool deactivated_by_bank { get; set; }
        public object bank_deactivation_reason { get; set; }
        public int bank_merchant_status { get; set; }
        public object national_id { get; set; }
        public object super_agent { get; set; }
        public object wallet_limit_profile { get; set; }
        public object address { get; set; }
        public object commercial_registration { get; set; }
        public object commercial_registration_area { get; set; }
        public object distributor_code { get; set; }
        public object distributor_branch_code { get; set; }
        public bool allow_terminal_order_id { get; set; }
        public bool allow_encryption_bypass { get; set; }
        public object wallet_phone_number { get; set; }
        public int suspicious { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public Bank_Staffs bank_staffs { get; set; }
        public object bank_rejection_reason { get; set; }
        public bool bank_received_documents { get; set; }
        public int bank_merchant_digital_status { get; set; }
        public object bank_digital_rejection_reason { get; set; }
        public bool filled_business_data { get; set; }
        public string day_start_time { get; set; }
        public object day_end_time { get; set; }
        public bool withhold_transfers { get; set; }
        public string sms_sender_name { get; set; }
        public object withhold_transfers_reason { get; set; }
        public object withhold_transfers_notes { get; set; }
        public bool can_bill_deposit_with_card { get; set; }
        public bool can_topup_merchants { get; set; }
        public object topup_transfer_id { get; set; }
        public bool referral_eligible { get; set; }
        public bool paymob_app_merchant { get; set; }
        public object settlement_frequency { get; set; }
        public object day_of_the_week { get; set; }
        public object day_of_the_month { get; set; }
        public bool allow_transaction_notifications { get; set; }
        public bool allow_transfer_notifications { get; set; }
        public int sallefny_amount_whole { get; set; }
        public int sallefny_fees_whole { get; set; }
        public object paymob_app_first_login { get; set; }
        public object paymob_app_last_activity { get; set; }
        public object acq_partner { get; set; }
        public string sales_owner { get; set; }
        public object dom { get; set; }
        public object bank_related { get; set; }
        public object[] permissions { get; set; }
    }

    public class PaymobUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_joined { get; set; }
        public string email { get; set; }
        public bool is_active { get; set; }
        public bool is_staff { get; set; }
        public bool is_superuser { get; set; }
        public object last_login { get; set; }
        public object[] groups { get; set; }
        public int[] user_permissions { get; set; }
    }

    public class Bank_Staffs
    {
    }

}
