using System;
namespace MozscapeAPI.NET.Constants
{
	public static class AnchorTextConstants
	{
		public static String ANCHOR_SCOPE_PHRASE_TO_PAGE = "phrase_to_page";
		public static String ANCHOR_SCOPE_PHRASE_TO_SUBDOMAIN = "phrase_to_subdomain";
		public static String ANCHOR_SCOPE_PHRASE_TO_DOMAIN = "phrase_to_domain";
		public static String ANCHOR_SCOPE_TERM_TO_PAGE = "term_to_page";
		public static String ANCHOR_SCOPE_TERM_TO_SUBDOMAIN = "term_to_subdomain";
		public static String ANCHOR_SCOPE_TERM_TO_DOMAIN = "term_to_domain";

		public static String ANCHOR_SORT_DOMAINS_LINKING_PAGE = "domains_linking_page";

		public static long ANCHOR_COL_ALL = 0;
		public static long ANCHOR_COL_TERM_OR_PHRASE = 2;
		public static long ANCHOR_COL_INTERNAL_PAGES_LINK = 8;
		public static long ANCHOR_COL_INTERNAL_SUBDMNS_LINK = 16;
		public static long ANCHOR_COL_EXTERNAL_PAGES_LINK = 32;
		public static long ANCHOR_COL_EXTERNAL_SUBDMNS_LINK = 64;
		public static long ANCHOR_COL_EXTERNAL_ROOTDMNS_LINK = 128;
		public static long ANCHOR_COL_INTERNAL_MOZRANK = 256;
		public static long ANCHOR_COL_EXTERNAL_MOZRANK = 512;
		public static long ANCHOR_COL_FLAGS = 1024;
	}
}
