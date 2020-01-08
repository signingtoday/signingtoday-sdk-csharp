/* 
 * Signing Today API
 *
 * KlNpZ25pbmcgVG9kYXkqIGVuYWJsZXMgc2VhbWxlc3MgaW50ZWdyYXRpb24gb2YgZGlnaXRhbCBzaWduYXR1cmVzIGludG8gYW55CndlYnNpdGUgYnkgdGhlIHVzZSBvZiBlYXN5IHJlcXVlc3RzIHRvIG91ciBBUEkuIFRoaXMgaXMgdGhlIHNtYXJ0IHdheSBvZgphZGRpbmcgZGlnaXRhbCBzaWduYXR1cmUgc3VwcG9ydCB3aXRoIGEgZ3JlYXQgdXNlciBleHBlcmllbmNlLgoKCipTaWduaW5nIFRvZGF5IEFQSXMqIHVzZSBIVFRQIG1ldGhvZHMgYW5kIGFyZSBSRVNUZnVsIGJhc2VkLCBtb3Jlb3ZlciB0aGV5CmFyZSBwcm90ZWN0ZWQgYnkgYSAqc2VydmVyIHRvIHNlcnZlciBhdXRoZW50aWNhdGlvbiogc3RhbmRhcmQgYnkgdGhlIHVzZSBvZgp0b2tlbnMuCgoKKlNpZ25pbmcgVG9kYXkgQVBJcyogY2FuIGJlIHVzZWQgaW4gdGhlc2UgZW52aXJvbm1lbnRzOgoKCnwgRW52aXJvbm1lbnQgfCBEZXNjcmlwdGlvbiB8IEVuZHBvaW50IHwKfCAtLS0tLS0tLS0tLSB8IC0tLS0tLS0tLS0tIHwgLS0tLS0tLS0gfAp8IFNhbmRib3ggICAgIHwgVGVzdCBlbnZpcm9ubWVudCB8IGBodHRwczovL3NhbmRib3guc2lnbmluZ3RvZGF5LmNvbWAgfAp8IExpdmUgICAgICAgIHwgUHJvZHVjdGlvbiBlbnZpcm9ubWVudCB8IGBodHRwczovL2FwaS5zaWduaW5ndG9kYXkuY29tYCB8CgoKRm9yIGV2ZXJ5IHNpbmdsZSByZXF1ZXN0IHRvIFNpZ25pbmcgVG9kYXkgaGFzIHRvIGJlIGRlZmluZWQgdGhlIGZvbGxvd2luZwoqSFRUUCogaGVhZGVyOgotIGBBdXRob3JpemF0aW9uYCwgd2hpY2ggY29udGFpbnMgdGhlIGF1dGhlbnRpY2F0aW9uIHRva2VuLgoKSWYgdGhlIHJlcXVlc3QgaGFzIGEgYm9keSB0aGFuIGFub3RoZXIgKkhUVFAqIGhlYWRlciBpcyByZXF1ZXN0ZWQ6Ci0gYENvbnRlbnQtVHlwZWAsIHdpdGggYGFwcGxpY2F0aW9uL2pzb25gIHZhbHVlLgoKCkZvbGxvd3MgYW4gZXhhbXBsZSBvZiB1c2FnZSB0byBlbnVtZXJhdGUgYWxsIHRoZSB1c2VyIG9mICpteS1vcmcqCm9yZ2FuaXphdGlvbi4KCioqRXhhbXBsZSoqCgpgYGBqc29uCiQgY3VybCBodHRwczovL3NhbmRib3guc2lnbmluZ3RvZGF5LmNvbS9hcGkvdjEvbXktb3JnL3VzZXJzIFwKICAgIC1IICdBdXRob3JpemF0aW9uOiBUb2tlbiA8YWNjZXNzLXRva2VuPicKYGBgCgojIyBIVFRQIG1ldGhvZHMgdXNlZAoKQVBJcyB1c2UgdGhlIHJpZ2h0IEhUVFAgdmVyYiBpbiBldmVyeSBzaXR1YXRpb24uCgp8IE1ldGhvZCAgIHwgRGVzY3JpcHRpb24gICAgICAgICAgICAgICAgICAgIHwKfCAtLS0tLS0tLSB8IC0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLSB8CnwgYEdFVGAgICAgfCBSZXF1ZXN0IGRhdGEgZnJvbSBhIHJlc291cmNlICAgfAp8IGBQT1NUYCAgIHwgU2VuZCBkYXRhIHRvIGNyZWF0ZSBhIHJlc291cmNlIHwKfCBgUFVUYCAgICB8IFVwZGF0ZSBhIHJlc291cmNlICAgICAgICAgICAgICB8CnwgYFBBVENIYCAgfCBQYXJ0aWFsbHkgdXBkYXRlIGEgcmVzb3VyY2UgICAgfAp8IGBERUxFVEVgIHwgRGVsZXRlIGEgcmVzb3Vyc2UgICAgICAgICAgICAgIHwKCgojIyBSZXNwb25zZSBkZWZpbml0aW9uCgpBbGwgdGhlIHJlc3BvbnNlIGFyZSBpbiBKU09OIGZvcm1hdC4KQXMgcmVzcG9uc2UgdG8gYSByZXF1ZXN0IG9mIGFsbCB1c2VycyBvZiBhbiBvcmdhbml6YXRpb24geW91IHdpbGwgaGF2ZSBhCnJlc3VsdCBsaWtlIHRoaXM6CgpgYGBqc29uCnsKICAgICJwYWdpbmF0aW9uIjogewogICAgICAiY291bnQiOiA3NSwKICAgICAgInByZXZpb3VzIjogImh0dHBzOi8vc2FuZGJveC5zaWduaW5ndG9kYXkuY29tL2FwaS92MS9teS1vcmcvdXNlcnM/cGFnZT0xIiwKICAgICAgIm5leHQiOiAiaHR0cHM6Ly9zYW5kYm94LnNpZ25pbmd0b2RheS5jb20vYXBpL3YxL215LW9yZy91c2Vycz9wYWdlPTMiLAogICAgICAicGFnZXMiOiA4LAogICAgICAicGFnZSI6IDIKICAgIH0sCiAgICAibWV0YSI6IHsKICAgICAgImNvZGUiOiAyMDAKICAgIH0sCiAgICAiZGF0YSI6IFsKICAgICAgewogICAgICAgICJpZCI6ICJqZG8iLAogICAgICAgICJzdGF0dXMiOiAiZW5hYmxlZCIsCiAgICAgICAgInR5cGUiOiAiQmFzaWMgdXNlciBhY2NvdW50IiwKICAgICAgICAiZW1haWwiOiBqb2huZG9lQGR1bW15ZW1haWwuY29tLAogICAgICAgICJmaXJzdF9uYW1lIjogIkpvaG4iLAogICAgICAgICJsYXN0X25hbWUiOiAiRG9lIiwKICAgICAgICAid2FsbGV0IjogW10sCiAgICAgICAgImNyZWF0ZWRfYnkiOiAic3lzdGVtIiwKICAgICAgICAib3duZXIiOiBmYWxzZSwKICAgICAgICAiYXV0b21hdGljIjogZmFsc2UsCiAgICAgICAgInJhbyI6IGZhbHNlCiAgICAgIH0sCiAgICAgIC4uLgogICAgXQogIH0KYGBgCgpUaGUgSlNPTiBvZiB0aGUgcmVzcG9uc2UgaXMgbWFkZSBvZiB0aHJlZSBwYXJ0czoKLSBQYWdpbmF0aW9uCi0gTWV0YQotIERhdGEKCiMjIyBQYWdpbmF0aW9uCgoqUGFnaW5hdGlvbiogb2JqZWN0IGFsbG93cyB0byBzcGxpdCB0aGUgcmVzcG9uc2UgaW50byBwYXJ0cyBhbmQgdGhlbiB0bwpyZWJ1aWxkIGl0IHNlcXVlbnRpYWxseSBieSB0aGUgdXNlIG9mIGBuZXh0YCBhbmQgYHByZXZpb3VzYCBwYXJhbWV0ZXJzLCBieQp3aGljaCB5b3UgZ2V0IHByZXZpb3VzIGFuZCBmb2xsb3dpbmcgYmxvY2tzLiBUaGUgKlBhZ2luYXRpb24qIGlzIHByZXNlbnQKb25seSBpZiB0aGUgcmVzcG9uc2UgaXMgYSBsaXN0IG9mIG9iamVjdHMuCgpUaGUgZ2VuZXJhbCBzdHJ1Y3R1cmUgb2YgKlBhZ2luYXRpb24qIG9iamVjdCBpcyB0aGUgZm9sbG93aW5nOgoKYGBganNvbgp7CiAgICAicGFnaW5hdGlvbiI6IHsKICAgICAgImNvdW50IjogNzUsCiAgICAgICJwcmV2aW91cyI6ICJodHRwczovL3NhbmRib3guc2lnbmluZ3RvZGF5LmNvbS9hcGkvdjEvbXktb3JnL3VzZXJzP3BhZ2U9MSIsCiAgICAgICJuZXh0IjogImh0dHBzOi8vc2FuZGJveC5zaWduaW5ndG9kYXkuY29tL2FwaS92MS9teS1vcmcvdXNlcnM/cGFnZT0zIiwKICAgICAgInBhZ2VzIjogOCwKICAgICAgInBhZ2UiOiAyCiAgICB9LAogICAgLi4uCiAgfQpgYGAKCiMjIyBNZXRhCgoqTWV0YSogb2JqZWN0IGlzIHVzZWQgdG8gZW5yaWNoIHRoZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUgcmVzcG9uc2UuIEluIHRoZQpwcmV2aW91cyBleGFtcGxlLCBhIHN1Y2Nlc3NmdWwgY2FzZSBvZiByZXNwb25zZSwgKk1ldGEqIHdpbGwgaGF2ZSB2YWx1ZQpgc3RhdHVzOiAyWFhgLiBJbiBjYXNlIG9mIHVuc3VjY2Vzc2Z1bCByZXNwb25zZSwgKk1ldGEqIHdpbGwgaGF2ZSBmdXJ0aGVyCmluZm9ybWF0aW9uLCBhcyBmb2xsb3dzOgoKYGBganNvbgp7CiAgICAibWV0YSI6IHsKICAgICAgImNvZGUiOiA8SFRUUCBTVEFUVVMgQ09ERT4sCiAgICAgICJlcnJvcl90eXBlIjogPFNUQVRVUyBDT0RFIERFU0NSSVBUSU9OPiwKICAgICAgImVycm9yX21lc3NhZ2UiOiA8RVJST1IgREVTQ1JJUFRJT04+CiAgICB9CiAgfQpgYGAKCiMjIyBEYXRhCgoqRGF0YSogb2JqZWN0IG91dHB1dHMgYXMgb2JqZWN0IG9yIGxpc3Qgb2YgdGhlbS4gQ29udGFpbnMgdGhlIGV4cGVjdGVkIGRhdGEKYXMgcmVxdWVzdGVkIHRvIHRoZSBBUEkuCgojIyBTZWFyY2ggZmlsdGVycwoKU2VhcmNoIGZpbHRlcnMgb2YgdGhlIEFQSSBoYXZlIHRoZSBmb2xsb3dpbmcgc3RydWN0dXJlOgoKYHdoZXJlX0FUVFJJQlVURU5BTUVgPWBWQUxVRWAKCkluIHRoaXMgd2F5IHlvdSBtYWtlIGEgY2FzZS1zZW5zaXRpdmUgc2VhcmNoIG9mICpWQUxVRSouIFlvdSBjYW4gZXh0ZW5kIGl0CnRocm91Z2ggdGhlIERqYW5nbyBsb29rdXAsIG9idGFpbmluZyBtb3JlIHNwZWNpZmljIGZpbHRlcnMuIEZvciBleGFtcGxlOgoKYHdoZXJlX0FUVFJJQlVURU5BTUVfX0xPT0tVUGA9YFZBTFVFYAoKd2hlcmUgKkxPT0tVUCogY2FuIGJlIHJlcGxhY2VkIHdpdGggYGljb250YWluc2AgdG8gaGF2ZSBhIHBhcnRpYWwgaW5zZW5zaXRpdmUKcmVzZWFyY2gsIHdoZXJlCgpgd2hlcmVfZmlyc3RfbmFtZV9faWNvbnRhaW5zYD1gQ0hhYAoKbWF0Y2hlcyB3aXRoIGV2ZXJ5IHVzZXIgdGhhdCBoYXZlIHRoZSAqY2hhKiBzdHJpbmcgaW4gdGhlaXIgbmFtZSwgd2l0aApubyBkaWZmZXJlbmNlcyBiZXR3ZWVuIGNhcGl0YWwgYW5kIGxvd2VyIGNhc2VzLgoKW0hlcmVdKGh0dHBzOi8vZG9jcy5kamFuZ29wcm9qZWN0LmNvbS9lbi8xLjExL3JlZi9tb2RlbHMvcXVlcnlzZXRzLyNmaWVsZC1sb29rdXBzKQp0aGUgbGlzdCBvZiB0aGUgbG9va3Vwcy4KCiMjIFdlYmhvb2tzCgpTaWduaW5nIFRvZGF5IHN1cHBvcnRzIHdlYmhvb2tzIGZvciB0aGUgdXBkYXRlIG9mIERTVHMgYW5kIGlkZW50aXRpZXMgc3RhdHVzLgpZb3UgY2FuIGNob29zZSBpZiB0byB1c2Ugb3Igbm90IHdlYmhvb2tzIGFuZCBpZiB5b3Ugd2FudCB0byByZWNlaXZlIHVwZGF0ZXMKYWJvdXQgRFNUcyBhbmQvb3IgaWRlbnRpdGllcy4gWW91IGNhbiBjb25maWd1cmF0ZSBpdCBvbiBhcHBsaWNhdGlvbiB0b2tlbgpsZXZlbCwgaW4gdGhlICp3ZWJob29rKiBmaWVsZCwgYXMgZm9sbG93czoKCmBgYGpzb24KIndlYmhvb2tzIjogewogICJkc3QiOiAiVVJMIiwKICAiaWRlbnRpdHkiOiAiVVJMIgogIH0KYGBgCgojIyMgRFNUcyBzdGF0dXMgdXBkYXRlCgpEU1RzIHNlbmQgdGhlIGZvbGxvd2luZyBzdGF0dXMgdXBkYXRlczoKLSAqKkRTVF9TVEFUVVNfQ0hBTkdFRCoqOiB3aGVuZXZlciB0aGUgRFNUIGNoYW5nZXMgaXRzIHN0YXR1cwotICoqU0lHTkFUVVJFX1NUQVRVU19DSEFOR0VEKio6IHdoZW5ldmVyIG9uZSBvZiB0aGUgc2lnbmF0dXJlcyBjaGFuZ2VzIGl0cwpzdGF0dXMKCiMjIyMgRFNUX1NUQVRVU19DSEFOR0VECgpTZW5kcyB0aGUgZm9sbG93aW5nIGluZm9ybWF0aW9uOgoKYGBganNvbgp7CiAgICAibWVzc2FnZSI6ICJEU1RfU1RBVFVTX0NIQU5HRUQiLAogICAgImRhdGEiOiB7CiAgICAgICJzdGF0dXMiOiAiPERTVF9TVEFUVVM+IiwKICAgICAgImRzdCI6ICI8RFNUX0lEPiIsCiAgICAgICJyZWFzb24iOiAiPERTVF9SRUFTT04+IgogICAgfQogIH0KYGBgCgojIyMjIFNJR05BVFVSRV9TVEFUVVNfQ0hBTkdFRAoKU2VuZHMgdGhlIGZvbGxvd2luZyBpbmZvcm1hdGlvbjoKCmBgYGpzb24KewogICAgIm1lc3NhZ2UiOiAiU0lHTkFUVVJFX1NUQVRVU19DSEFOR0VEIiwKICAgICJkYXRhIjogewogICAgICAic3RhdHVzIjogIjxTSUdOQVRVUkVfU1RBVFVTPiIsCiAgICAgICJncm91cCI6IDxNRU1CRVJTSElQX0dST1VQX0lOREVYPiwKICAgICAgImRzdCI6IHsKICAgICAgICAiaWQiOiAiPERTVF9JRD4iLAogICAgICAgICJ0aXRsZSI6ICI8RFNUX1RJVExFPiIKICAgICAgfSwKICAgICAgInNpZ25hdHVyZSI6ICI8U0lHTkFUVVJFX0lEPiIsCiAgICAgICJzaWduZXIiOiAiPFNJR05FUl9VU0VSTkFNRT4iLAogICAgICAicG9zaXRpb24iOiAiPFNJR05BVFVSRV9QT1NJVElPTj4iLAogICAgICAiZG9jdW1lbnQiOiB7CiAgICAgICAgImRpc3BsYXlfbmFtZSI6ICI8RE9DVU1FTlRfVElUTEU+IiwKICAgICAgICAiaWQiOiAiPERPQ1VNRU5UX0lEPiIsCiAgICAgICAgIm9yZGVyIjogPERPQ1VNRU5UX0lOREVYPgogICAgICB9LAogICAgICAiYXV0b21hdGljIjogPERFQ0xBUkVTX0lGX1RIRV9TSUdORVJfSVNfQVVUT01BVElDPiwKICAgICAgInBhZ2UiOiAiPFNJR05BVFVSRV9QQUdFPiIKICAgIH0KICB9CmBgYAoKIyMjIElkZW50aXRpZXMgc3RhdHVzIHVwZGF0ZQoKSWRlbnRpdGllcyBzZW5kIHRoZSBmb2xsb3dpbmcgc3RhdHVzIHVwZGF0ZXM6Ci0gKipJREVOVElUWV9SRVFVRVNUX0VOUk9MTEVEKio6IHdoZW5ldmVyIGFuIGlkZW50aXR5IHJlcXVlc3QgaXMgYWN0aXZhdGVkCgojIyMjIElERU5USVRZX1JFUVVFU1RfRU5ST0xMRUQKClNlbmRzIHRoZSBmb2xsb3dpbmcgaW5mb3JtYXRpb246CgpgYGBqc29uCnsKICAgICJtZXNzYWdlIjogIklERU5USVRZX1JFUVVFU1RfRU5ST0xMRUQiLAogICAgImRhdGEiOiB7CiAgICAgICJzdGF0dXMiOiAiPFJFUVVFU1RfU1RBVFVTPiIsCiAgICAgICJyZXF1ZXN0IjogIjxSRVFVRVNUX0lEPiIsCiAgICAgICJ1c2VyIjogIjxBUFBMSUNBTlRfVVNFUk5BTUU+IgogICAgfQogIH0KYGBgCgojIyMgVXJsYmFjawoKU29tZXRpbWVzIG1heSBiZSBuZWNlc3NhcnkgdG8gbWFrZSBhIHJlZGlyZWN0IGFmdGVyIGFuIHVzZXIsIGZyb20gdGhlCnNpZ25hdHVyZSB0cmF5LCBoYXMgY29tcGxldGVkIGhpcyBvcGVyYXRpb25zIG9yIGFjdGl2YXRlZCBhIGNlcnRpZmljYXRlLgoKSWYgc2V0LCByZWRpcmVjdHMgY291bGQgaGFwcGVuIGluIDMgY2FzZXM6Ci0gYWZ0ZXIgYSBzaWduYXR1cmUgb3IgZGVjbGluZQotIGFmdGVyIGEgRFNUIGhhcyBiZWVuIHNpZ25lZCBieSBhbGwgdGhlIHNpZ25lcnMgb3IgY2FuY2VsZWQKLSBhZnRlciB0aGUgYWN0aXZhdGlvbiBvZiBhIGNlcnRpZmljYXRlCgpJbiB0aGUgZmlyc3QgdHdvIGNhc2VzIHRoZSB1cmxiYWNrIHJldHVybnMgdGhlIGZvbGxvd2luZyBpbmZvcm1hdGlvbiB0aHJvdWdoCmEgZGF0YSBmb3JtOgotICoqZHN0LWlkKio6IGlkIG9mIHRoZSBEU1QKLSAqKmRzdC11cmwqKjogc2lnbmF0dXJlX3RpY2tldCBvZiB0aGUgc2lnbmF0dXJlCi0gKipkc3Qtc3RhdHVzKio6IGN1cnJlbnQgc3RhdHVzIG9mIHRoZSBEU1QKLSAqKmRzdC1zaWduYXR1cmUtaWQqKjogaWQgb2YgdGhlIHNpZ25hdHVyZQotICoqZHN0LXNpZ25hdHVyZS1zdGF0dXMqKjogY3VycmVudCBzdGF0dXMgb2YgdGhlIHNpZ25hdHVyZQotICoqdXNlcioqOiB1c2VybmFtZSBvZiB0aGUgc2lnbmVyCi0gKipkZWNsaW5lLXJlYXNvbioqOiBpbiBjYXNlIG9mIGEgcmVmdXNlZCBEU1QgY29udGFpbnMgdGhlIHJlYXNvbiBvZiB0aGUKZGVjbGluZQoKSW4gdGhlIGxhc3QgY2FzZSB0aGUgdXJsYmFjayByZXR1cm5zIHRoZSBmb2xsb3dpbmcgaW5mb3JtYXRpb24gdGhyb3VnaCBhCmRhdGEgZm9ybToKLSAqKnVzZXIqKjogdXNlcm5hbWUgb2YgdGhlIHVzZXIgYWN0aXZhdGVkIHRoZSBjZXJ0aWZpY2F0ZQotICoqaWRlbnRpdHktcHJvdmlkZXIqKjogdGhlIHByb3ZpZGVyIGhhcyBiZWVuIHVzZWQgdG8gaXNzdWUgdGhlIGNlcnRpZmljYXRlCi0gKippZGVudGl0eS1yZXF1ZXN0LWlkKio6IGlkIG9mIHRoZSBlbnJvbGxtZW50IHJlcXVlc3QKLSAqKmlkZW50aXR5LWlkKio6IGlkIG9mIHRoZSBuZXcgaWRlbnRpdHkKLSAqKmlkZW50aXR5LWxhYmVsKio6IHRoZSBsYWJlbCBhc3NpZ25lZCB0byB0aGUgaWRlbnRpdHkKLSAqKmlkZW50aXR5LWNlcnRpZmljYXRlKio6IHB1YmxpYyBrZXkgb2YgdGhlIGNlcnRpZmljYXRlCgoK
 *
 * The version of the OpenAPI document: 1.5.0
 * Contact: smartcloud@bit4id.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using SigningToday.Client;
using SigningToday.Model;

namespace SigningToday.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBit4idPathgroupSignatureTransactionsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Mark a DST as canceled
        /// </summary>
        /// <remarks>
        /// This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject1"></param>
        /// <returns>InlineResponse2013</returns>
        InlineResponse2013 CancelDST (string organizationId, Id dstId, InlineObject1 inlineObject1);

        /// <summary>
        /// Mark a DST as canceled
        /// </summary>
        /// <remarks>
        /// This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject1"></param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        ApiResponse<InlineResponse2013> CancelDSTWithHttpInfo (string organizationId, Id dstId, InlineObject1 inlineObject1);
        /// <summary>
        /// Create a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to create a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>InlineResponse2013</returns>
        InlineResponse2013 CreateDST (string organizationId, CreateSignatureTransaction createSignatureTransaction);

        /// <summary>
        /// Create a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to create a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        ApiResponse<InlineResponse2013> CreateDSTWithHttpInfo (string organizationId, CreateSignatureTransaction createSignatureTransaction);
        /// <summary>
        /// Delete a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to delete a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2007</returns>
        InlineResponse2007 DeleteDST (string organizationId, Id dstId);

        /// <summary>
        /// Delete a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to delete a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2007</returns>
        ApiResponse<InlineResponse2007> DeleteDSTWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Get information about a DST
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2013</returns>
        InlineResponse2013 GetDST (string organizationId, Id dstId);

        /// <summary>
        /// Get information about a DST
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        ApiResponse<InlineResponse2013> GetDSTWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Download a document from a DST
        /// </summary>
        /// <remarks>
        /// This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetDocument (string organizationId, Id documentId);

        /// <summary>
        /// Download a document from a DST
        /// </summary>
        /// <remarks>
        /// This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>ApiResponse of System.IO.Stream</returns>
        ApiResponse<System.IO.Stream> GetDocumentWithHttpInfo (string organizationId, Id documentId);
        /// <summary>
        /// List the DSTs of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to list the Digital Signature Transactions of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2006</returns>
        InlineResponse2006 ListDSTs (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int));

        /// <summary>
        /// List the DSTs of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to list the Digital Signature Transactions of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2006</returns>
        ApiResponse<InlineResponse2006> ListDSTsWithHttpInfo (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int));
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Mark a DST as canceled
        /// </summary>
        /// <remarks>
        /// This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject1"></param>
        /// <returns>Task of InlineResponse2013</returns>
        System.Threading.Tasks.Task<InlineResponse2013> CancelDSTAsync (string organizationId, Id dstId, InlineObject1 inlineObject1);

        /// <summary>
        /// Mark a DST as canceled
        /// </summary>
        /// <remarks>
        /// This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject1"></param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> CancelDSTAsyncWithHttpInfo (string organizationId, Id dstId, InlineObject1 inlineObject1);
        /// <summary>
        /// Create a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to create a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>Task of InlineResponse2013</returns>
        System.Threading.Tasks.Task<InlineResponse2013> CreateDSTAsync (string organizationId, CreateSignatureTransaction createSignatureTransaction);

        /// <summary>
        /// Create a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to create a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> CreateDSTAsyncWithHttpInfo (string organizationId, CreateSignatureTransaction createSignatureTransaction);
        /// <summary>
        /// Delete a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to delete a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2007</returns>
        System.Threading.Tasks.Task<InlineResponse2007> DeleteDSTAsync (string organizationId, Id dstId);

        /// <summary>
        /// Delete a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to delete a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2007)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2007>> DeleteDSTAsyncWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Get information about a DST
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2013</returns>
        System.Threading.Tasks.Task<InlineResponse2013> GetDSTAsync (string organizationId, Id dstId);

        /// <summary>
        /// Get information about a DST
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> GetDSTAsyncWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Download a document from a DST
        /// </summary>
        /// <remarks>
        /// This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>Task of System.IO.Stream</returns>
        System.Threading.Tasks.Task<System.IO.Stream> GetDocumentAsync (string organizationId, Id documentId);

        /// <summary>
        /// Download a document from a DST
        /// </summary>
        /// <remarks>
        /// This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>Task of ApiResponse (System.IO.Stream)</returns>
        System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetDocumentAsyncWithHttpInfo (string organizationId, Id documentId);
        /// <summary>
        /// List the DSTs of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to list the Digital Signature Transactions of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2006</returns>
        System.Threading.Tasks.Task<InlineResponse2006> ListDSTsAsync (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int));

        /// <summary>
        /// List the DSTs of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to list the Digital Signature Transactions of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2006)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2006>> ListDSTsAsyncWithHttpInfo (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class Bit4idPathgroupSignatureTransactionsApi : IBit4idPathgroupSignatureTransactionsApi
    {
        private SigningToday.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignatureTransactionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public Bit4idPathgroupSignatureTransactionsApi(String basePath)
        {
            this.Configuration = new SigningToday.Client.Configuration { BasePath = basePath };

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignatureTransactionsApi"/> class
        /// </summary>
        /// <returns></returns>
        public Bit4idPathgroupSignatureTransactionsApi()
        {
            this.Configuration = SigningToday.Client.Configuration.Default;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignatureTransactionsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public Bit4idPathgroupSignatureTransactionsApi(SigningToday.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = SigningToday.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public SigningToday.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public SigningToday.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Mark a DST as canceled This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject1"></param>
        /// <returns>InlineResponse2013</returns>
        public InlineResponse2013 CancelDST (string organizationId, Id dstId, InlineObject1 inlineObject1)
        {
             ApiResponse<InlineResponse2013> localVarResponse = CancelDSTWithHttpInfo(organizationId, dstId, inlineObject1);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Mark a DST as canceled This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject1"></param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        public ApiResponse<InlineResponse2013> CancelDSTWithHttpInfo (string organizationId, Id dstId, InlineObject1 inlineObject1)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");
            // verify the required parameter 'inlineObject1' is set
            if (inlineObject1 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject1' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}/cancel";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter
            if (inlineObject1 != null && inlineObject1.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject1); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject1; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CancelDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Mark a DST as canceled This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject1"></param>
        /// <returns>Task of InlineResponse2013</returns>
        public async System.Threading.Tasks.Task<InlineResponse2013> CancelDSTAsync (string organizationId, Id dstId, InlineObject1 inlineObject1)
        {
             ApiResponse<InlineResponse2013> localVarResponse = await CancelDSTAsyncWithHttpInfo(organizationId, dstId, inlineObject1);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Mark a DST as canceled This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject1"></param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> CancelDSTAsyncWithHttpInfo (string organizationId, Id dstId, InlineObject1 inlineObject1)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");
            // verify the required parameter 'inlineObject1' is set
            if (inlineObject1 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject1' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}/cancel";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter
            if (inlineObject1 != null && inlineObject1.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject1); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject1; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CancelDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Create a Digital Signature Transaction This API allows to create a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>InlineResponse2013</returns>
        public InlineResponse2013 CreateDST (string organizationId, CreateSignatureTransaction createSignatureTransaction)
        {
             ApiResponse<InlineResponse2013> localVarResponse = CreateDSTWithHttpInfo(organizationId, createSignatureTransaction);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a Digital Signature Transaction This API allows to create a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        public ApiResponse<InlineResponse2013> CreateDSTWithHttpInfo (string organizationId, CreateSignatureTransaction createSignatureTransaction)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->CreateDST");
            // verify the required parameter 'createSignatureTransaction' is set
            if (createSignatureTransaction == null)
                throw new ApiException(400, "Missing required parameter 'createSignatureTransaction' when calling Bit4idPathgroupSignatureTransactionsApi->CreateDST");

            var localVarPath = "/{organization-id}/signature-transactions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (createSignatureTransaction != null && createSignatureTransaction.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createSignatureTransaction); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createSignatureTransaction; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Create a Digital Signature Transaction This API allows to create a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>Task of InlineResponse2013</returns>
        public async System.Threading.Tasks.Task<InlineResponse2013> CreateDSTAsync (string organizationId, CreateSignatureTransaction createSignatureTransaction)
        {
             ApiResponse<InlineResponse2013> localVarResponse = await CreateDSTAsyncWithHttpInfo(organizationId, createSignatureTransaction);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a Digital Signature Transaction This API allows to create a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> CreateDSTAsyncWithHttpInfo (string organizationId, CreateSignatureTransaction createSignatureTransaction)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->CreateDST");
            // verify the required parameter 'createSignatureTransaction' is set
            if (createSignatureTransaction == null)
                throw new ApiException(400, "Missing required parameter 'createSignatureTransaction' when calling Bit4idPathgroupSignatureTransactionsApi->CreateDST");

            var localVarPath = "/{organization-id}/signature-transactions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (createSignatureTransaction != null && createSignatureTransaction.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createSignatureTransaction); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createSignatureTransaction; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Delete a Digital Signature Transaction This API allows to delete a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2007</returns>
        public InlineResponse2007 DeleteDST (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2007> localVarResponse = DeleteDSTWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete a Digital Signature Transaction This API allows to delete a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2007</returns>
        public ApiResponse<InlineResponse2007> DeleteDSTWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2007>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2007) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
        }

        /// <summary>
        /// Delete a Digital Signature Transaction This API allows to delete a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2007</returns>
        public async System.Threading.Tasks.Task<InlineResponse2007> DeleteDSTAsync (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2007> localVarResponse = await DeleteDSTAsyncWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete a Digital Signature Transaction This API allows to delete a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2007)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2007>> DeleteDSTAsyncWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2007>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2007) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
        }

        /// <summary>
        /// Get information about a DST This API allows to get information about a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2013</returns>
        public InlineResponse2013 GetDST (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2013> localVarResponse = GetDSTWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about a DST This API allows to get information about a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        public ApiResponse<InlineResponse2013> GetDSTWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Get information about a DST This API allows to get information about a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2013</returns>
        public async System.Threading.Tasks.Task<InlineResponse2013> GetDSTAsync (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2013> localVarResponse = await GetDSTAsyncWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get information about a DST This API allows to get information about a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> GetDSTAsyncWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Download a document from a DST This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>System.IO.Stream</returns>
        public System.IO.Stream GetDocument (string organizationId, Id documentId)
        {
             ApiResponse<System.IO.Stream> localVarResponse = GetDocumentWithHttpInfo(organizationId, documentId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Download a document from a DST This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>ApiResponse of System.IO.Stream</returns>
        public ApiResponse<System.IO.Stream> GetDocumentWithHttpInfo (string organizationId, Id documentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDocument");
            // verify the required parameter 'documentId' is set
            if (documentId == null)
                throw new ApiException(400, "Missing required parameter 'documentId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDocument");

            var localVarPath = "/{organization-id}/documents/{document-id}/download";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/pdf",
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (documentId != null) localVarPathParams.Add("document-id", this.Configuration.ApiClient.ParameterToString(documentId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDocument", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<System.IO.Stream>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (System.IO.Stream) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(System.IO.Stream)));
        }

        /// <summary>
        /// Download a document from a DST This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>Task of System.IO.Stream</returns>
        public async System.Threading.Tasks.Task<System.IO.Stream> GetDocumentAsync (string organizationId, Id documentId)
        {
             ApiResponse<System.IO.Stream> localVarResponse = await GetDocumentAsyncWithHttpInfo(organizationId, documentId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Download a document from a DST This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>Task of ApiResponse (System.IO.Stream)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetDocumentAsyncWithHttpInfo (string organizationId, Id documentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDocument");
            // verify the required parameter 'documentId' is set
            if (documentId == null)
                throw new ApiException(400, "Missing required parameter 'documentId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDocument");

            var localVarPath = "/{organization-id}/documents/{document-id}/download";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/pdf",
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (documentId != null) localVarPathParams.Add("document-id", this.Configuration.ApiClient.ParameterToString(documentId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDocument", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<System.IO.Stream>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (System.IO.Stream) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(System.IO.Stream)));
        }

        /// <summary>
        /// List the DSTs of an organization This API allows to list the Digital Signature Transactions of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2006</returns>
        public InlineResponse2006 ListDSTs (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2006> localVarResponse = ListDSTsWithHttpInfo(organizationId, whereSigner, whereStatus, whereTitle, whereCreatedBy, whereCreated, whereSignatureStatus, whereDocumentName, whereReason, whereSignatureName, whereSignerGroup, page, count);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List the DSTs of an organization This API allows to list the Digital Signature Transactions of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2006</returns>
        public ApiResponse<InlineResponse2006> ListDSTsWithHttpInfo (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->ListDSTs");

            var localVarPath = "/{organization-id}/signature-transactions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (whereSigner != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signer", whereSigner)); // query parameter
            if (whereStatus != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_status", whereStatus)); // query parameter
            if (whereTitle != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_title", whereTitle)); // query parameter
            if (whereCreatedBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_created_by", whereCreatedBy)); // query parameter
            if (whereCreated != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_created", whereCreated)); // query parameter
            if (whereSignatureStatus != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signature_status", whereSignatureStatus)); // query parameter
            if (whereDocumentName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_document_name", whereDocumentName)); // query parameter
            if (whereReason != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_reason", whereReason)); // query parameter
            if (whereSignatureName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signature_name", whereSignatureName)); // query parameter
            if (whereSignerGroup != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signer_group", whereSignerGroup)); // query parameter
            if (page != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "page", page)); // query parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ListDSTs", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2006>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2006) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2006)));
        }

        /// <summary>
        /// List the DSTs of an organization This API allows to list the Digital Signature Transactions of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2006</returns>
        public async System.Threading.Tasks.Task<InlineResponse2006> ListDSTsAsync (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2006> localVarResponse = await ListDSTsAsyncWithHttpInfo(organizationId, whereSigner, whereStatus, whereTitle, whereCreatedBy, whereCreated, whereSignatureStatus, whereDocumentName, whereReason, whereSignatureName, whereSignerGroup, page, count);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List the DSTs of an organization This API allows to list the Digital Signature Transactions of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2006)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2006>> ListDSTsAsyncWithHttpInfo (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->ListDSTs");

            var localVarPath = "/{organization-id}/signature-transactions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (whereSigner != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signer", whereSigner)); // query parameter
            if (whereStatus != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_status", whereStatus)); // query parameter
            if (whereTitle != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_title", whereTitle)); // query parameter
            if (whereCreatedBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_created_by", whereCreatedBy)); // query parameter
            if (whereCreated != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_created", whereCreated)); // query parameter
            if (whereSignatureStatus != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signature_status", whereSignatureStatus)); // query parameter
            if (whereDocumentName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_document_name", whereDocumentName)); // query parameter
            if (whereReason != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_reason", whereReason)); // query parameter
            if (whereSignatureName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signature_name", whereSignatureName)); // query parameter
            if (whereSignerGroup != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signer_group", whereSignerGroup)); // query parameter
            if (page != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "page", page)); // query parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ListDSTs", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2006>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2006) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2006)));
        }

    }
}
