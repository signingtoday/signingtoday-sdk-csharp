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
    public interface IIdentitiesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Associate an appearance to an identity
        /// </summary>
        /// <remarks>
        /// Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>InlineResponse2004</returns>
        InlineResponse2004 AssociateAppearance (string organizationId, Id identityId, InlineObject inlineObject);

        /// <summary>
        /// Associate an appearance to an identity
        /// </summary>
        /// <remarks>
        /// Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        ApiResponse<InlineResponse2004> AssociateAppearanceWithHttpInfo (string organizationId, Id identityId, InlineObject inlineObject);
        /// <summary>
        /// Associate to an user an already existing identity
        /// </summary>
        /// <remarks>
        /// Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>InlineResponse2004</returns>
        InlineResponse2004 AssociateIdentity (string organizationId, Id userId, IdentityAssociation identityAssociation);

        /// <summary>
        /// Associate to an user an already existing identity
        /// </summary>
        /// <remarks>
        /// Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        ApiResponse<InlineResponse2004> AssociateIdentityWithHttpInfo (string organizationId, Id userId, IdentityAssociation identityAssociation);
        /// <summary>
        /// Create an identity from token
        /// </summary>
        /// <remarks>
        /// This API allows to create an identity from a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>InlineResponse2012</returns>
        InlineResponse2012 CreateTokenFromIdentity (string organizationId, CreateIdentitybyToken createIdentitybyToken);

        /// <summary>
        /// Create an identity from token
        /// </summary>
        /// <remarks>
        /// This API allows to create an identity from a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        ApiResponse<InlineResponse2012> CreateTokenFromIdentityWithHttpInfo (string organizationId, CreateIdentitybyToken createIdentitybyToken);
        /// <summary>
        /// Delete the appearance of an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete the appearance associated to an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2004</returns>
        InlineResponse2004 DeleteAppearance (string organizationId, Id identityId);

        /// <summary>
        /// Delete the appearance of an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete the appearance associated to an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        ApiResponse<InlineResponse2004> DeleteAppearanceWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Delete an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to delete an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>InlineResponse2012</returns>
        InlineResponse2012 DeleteEnrollmentRequest (string organizationId, Id enrollmentId);

        /// <summary>
        /// Delete an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to delete an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        ApiResponse<InlineResponse2012> DeleteEnrollmentRequestWithHttpInfo (string organizationId, Id enrollmentId);
        /// <summary>
        /// Delete an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete an identity of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2003</returns>
        InlineResponse2003 DeleteIdentity (string organizationId, Id identityId);

        /// <summary>
        /// Delete an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete an identity of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2003</returns>
        ApiResponse<InlineResponse2003> DeleteIdentityWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Get information about an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to get information about an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>InlineResponse2011</returns>
        InlineResponse2011 GetEnrollmentRequest (string organizationId, Id enrollmentId);

        /// <summary>
        /// Get information about an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to get information about an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        ApiResponse<InlineResponse2011> GetEnrollmentRequestWithHttpInfo (string organizationId, Id enrollmentId);
        /// <summary>
        /// Get information about an identity
        /// </summary>
        /// <remarks>
        /// This API allows to get all the information of an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2002</returns>
        InlineResponse2002 GetIdentity (string organizationId, Id identityId);

        /// <summary>
        /// Get information about an identity
        /// </summary>
        /// <remarks>
        /// This API allows to get all the information of an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        ApiResponse<InlineResponse2002> GetIdentityWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Enumerate the enrollment requests of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the enrollment requests of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2005</returns>
        InlineResponse2005 ListEnrollmentRequests (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int));

        /// <summary>
        /// Enumerate the enrollment requests of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the enrollment requests of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2005</returns>
        ApiResponse<InlineResponse2005> ListEnrollmentRequestsWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int));
        /// <summary>
        /// Enumerate the identities of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2001</returns>
        InlineResponse2001 ListIdentities (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int));

        /// <summary>
        /// Enumerate the identities of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2001</returns>
        ApiResponse<InlineResponse2001> ListIdentitiesWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int));
        /// <summary>
        /// List the enrollments of an user
        /// </summary>
        /// <remarks>
        /// This API allows to list all the enrollments of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2005</returns>
        InlineResponse2005 ListUserEnrollments (string organizationId, Id userId, int page = default(int), int count = default(int));

        /// <summary>
        /// List the enrollments of an user
        /// </summary>
        /// <remarks>
        /// This API allows to list all the enrollments of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2005</returns>
        ApiResponse<InlineResponse2005> ListUserEnrollmentsWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int));
        /// <summary>
        /// Enumerate the identities of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2001</returns>
        InlineResponse2001 ListUserIdentities (string organizationId, Id userId, int page = default(int), int count = default(int));

        /// <summary>
        /// Enumerate the identities of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2001</returns>
        ApiResponse<InlineResponse2001> ListUserIdentitiesWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int));
        /// <summary>
        /// Submit an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>InlineResponse2011</returns>
        InlineResponse2011 RequestEnrollment (string organizationId, IdentityRequest identityRequest);

        /// <summary>
        /// Submit an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        ApiResponse<InlineResponse2011> RequestEnrollmentWithHttpInfo (string organizationId, IdentityRequest identityRequest);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Associate an appearance to an identity
        /// </summary>
        /// <remarks>
        /// Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>Task of InlineResponse2004</returns>
        System.Threading.Tasks.Task<InlineResponse2004> AssociateAppearanceAsync (string organizationId, Id identityId, InlineObject inlineObject);

        /// <summary>
        /// Associate an appearance to an identity
        /// </summary>
        /// <remarks>
        /// Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> AssociateAppearanceAsyncWithHttpInfo (string organizationId, Id identityId, InlineObject inlineObject);
        /// <summary>
        /// Associate to an user an already existing identity
        /// </summary>
        /// <remarks>
        /// Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>Task of InlineResponse2004</returns>
        System.Threading.Tasks.Task<InlineResponse2004> AssociateIdentityAsync (string organizationId, Id userId, IdentityAssociation identityAssociation);

        /// <summary>
        /// Associate to an user an already existing identity
        /// </summary>
        /// <remarks>
        /// Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> AssociateIdentityAsyncWithHttpInfo (string organizationId, Id userId, IdentityAssociation identityAssociation);
        /// <summary>
        /// Create an identity from token
        /// </summary>
        /// <remarks>
        /// This API allows to create an identity from a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>Task of InlineResponse2012</returns>
        System.Threading.Tasks.Task<InlineResponse2012> CreateTokenFromIdentityAsync (string organizationId, CreateIdentitybyToken createIdentitybyToken);

        /// <summary>
        /// Create an identity from token
        /// </summary>
        /// <remarks>
        /// This API allows to create an identity from a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> CreateTokenFromIdentityAsyncWithHttpInfo (string organizationId, CreateIdentitybyToken createIdentitybyToken);
        /// <summary>
        /// Delete the appearance of an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete the appearance associated to an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2004</returns>
        System.Threading.Tasks.Task<InlineResponse2004> DeleteAppearanceAsync (string organizationId, Id identityId);

        /// <summary>
        /// Delete the appearance of an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete the appearance associated to an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> DeleteAppearanceAsyncWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Delete an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to delete an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of InlineResponse2012</returns>
        System.Threading.Tasks.Task<InlineResponse2012> DeleteEnrollmentRequestAsync (string organizationId, Id enrollmentId);

        /// <summary>
        /// Delete an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to delete an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> DeleteEnrollmentRequestAsyncWithHttpInfo (string organizationId, Id enrollmentId);
        /// <summary>
        /// Delete an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete an identity of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2003</returns>
        System.Threading.Tasks.Task<InlineResponse2003> DeleteIdentityAsync (string organizationId, Id identityId);

        /// <summary>
        /// Delete an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete an identity of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2003)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2003>> DeleteIdentityAsyncWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Get information about an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to get information about an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of InlineResponse2011</returns>
        System.Threading.Tasks.Task<InlineResponse2011> GetEnrollmentRequestAsync (string organizationId, Id enrollmentId);

        /// <summary>
        /// Get information about an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to get information about an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> GetEnrollmentRequestAsyncWithHttpInfo (string organizationId, Id enrollmentId);
        /// <summary>
        /// Get information about an identity
        /// </summary>
        /// <remarks>
        /// This API allows to get all the information of an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2002</returns>
        System.Threading.Tasks.Task<InlineResponse2002> GetIdentityAsync (string organizationId, Id identityId);

        /// <summary>
        /// Get information about an identity
        /// </summary>
        /// <remarks>
        /// This API allows to get all the information of an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> GetIdentityAsyncWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Enumerate the enrollment requests of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the enrollment requests of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2005</returns>
        System.Threading.Tasks.Task<InlineResponse2005> ListEnrollmentRequestsAsync (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int));

        /// <summary>
        /// Enumerate the enrollment requests of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the enrollment requests of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2005)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2005>> ListEnrollmentRequestsAsyncWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int));
        /// <summary>
        /// Enumerate the identities of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2001</returns>
        System.Threading.Tasks.Task<InlineResponse2001> ListIdentitiesAsync (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int));

        /// <summary>
        /// Enumerate the identities of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2001)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2001>> ListIdentitiesAsyncWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int));
        /// <summary>
        /// List the enrollments of an user
        /// </summary>
        /// <remarks>
        /// This API allows to list all the enrollments of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2005</returns>
        System.Threading.Tasks.Task<InlineResponse2005> ListUserEnrollmentsAsync (string organizationId, Id userId, int page = default(int), int count = default(int));

        /// <summary>
        /// List the enrollments of an user
        /// </summary>
        /// <remarks>
        /// This API allows to list all the enrollments of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2005)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2005>> ListUserEnrollmentsAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int));
        /// <summary>
        /// Enumerate the identities of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2001</returns>
        System.Threading.Tasks.Task<InlineResponse2001> ListUserIdentitiesAsync (string organizationId, Id userId, int page = default(int), int count = default(int));

        /// <summary>
        /// Enumerate the identities of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2001)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2001>> ListUserIdentitiesAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int));
        /// <summary>
        /// Submit an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>Task of InlineResponse2011</returns>
        System.Threading.Tasks.Task<InlineResponse2011> RequestEnrollmentAsync (string organizationId, IdentityRequest identityRequest);

        /// <summary>
        /// Submit an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> RequestEnrollmentAsyncWithHttpInfo (string organizationId, IdentityRequest identityRequest);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IdentitiesApi : IIdentitiesApi
    {
        private SigningToday.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentitiesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public IdentitiesApi(String basePath)
        {
            this.Configuration = new SigningToday.Client.Configuration { BasePath = basePath };

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentitiesApi"/> class
        /// </summary>
        /// <returns></returns>
        public IdentitiesApi()
        {
            this.Configuration = SigningToday.Client.Configuration.Default;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentitiesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public IdentitiesApi(SigningToday.Client.Configuration configuration = null)
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
        /// Associate an appearance to an identity Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>InlineResponse2004</returns>
        public InlineResponse2004 AssociateAppearance (string organizationId, Id identityId, InlineObject inlineObject)
        {
             ApiResponse<InlineResponse2004> localVarResponse = AssociateAppearanceWithHttpInfo(organizationId, identityId, inlineObject);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Associate an appearance to an identity Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        public ApiResponse<InlineResponse2004> AssociateAppearanceWithHttpInfo (string organizationId, Id identityId, InlineObject inlineObject)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->AssociateAppearance");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->AssociateAppearance");
            // verify the required parameter 'inlineObject' is set
            if (inlineObject == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject' when calling IdentitiesApi->AssociateAppearance");

            var localVarPath = "/{organization-id}/identities/{identity-id}/appearance";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter
            if (inlineObject != null && inlineObject.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject; // byte array
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
                Exception exception = ExceptionFactory("AssociateAppearance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Associate an appearance to an identity Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>Task of InlineResponse2004</returns>
        public async System.Threading.Tasks.Task<InlineResponse2004> AssociateAppearanceAsync (string organizationId, Id identityId, InlineObject inlineObject)
        {
             ApiResponse<InlineResponse2004> localVarResponse = await AssociateAppearanceAsyncWithHttpInfo(organizationId, identityId, inlineObject);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Associate an appearance to an identity Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> AssociateAppearanceAsyncWithHttpInfo (string organizationId, Id identityId, InlineObject inlineObject)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->AssociateAppearance");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->AssociateAppearance");
            // verify the required parameter 'inlineObject' is set
            if (inlineObject == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject' when calling IdentitiesApi->AssociateAppearance");

            var localVarPath = "/{organization-id}/identities/{identity-id}/appearance";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter
            if (inlineObject != null && inlineObject.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject; // byte array
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
                Exception exception = ExceptionFactory("AssociateAppearance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Associate to an user an already existing identity Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>InlineResponse2004</returns>
        public InlineResponse2004 AssociateIdentity (string organizationId, Id userId, IdentityAssociation identityAssociation)
        {
             ApiResponse<InlineResponse2004> localVarResponse = AssociateIdentityWithHttpInfo(organizationId, userId, identityAssociation);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Associate to an user an already existing identity Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        public ApiResponse<InlineResponse2004> AssociateIdentityWithHttpInfo (string organizationId, Id userId, IdentityAssociation identityAssociation)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->AssociateIdentity");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->AssociateIdentity");
            // verify the required parameter 'identityAssociation' is set
            if (identityAssociation == null)
                throw new ApiException(400, "Missing required parameter 'identityAssociation' when calling IdentitiesApi->AssociateIdentity");

            var localVarPath = "/{organization-id}/users/{user-id}/wallet";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            if (identityAssociation != null && identityAssociation.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(identityAssociation); // http body (model) parameter
            }
            else
            {
                localVarPostBody = identityAssociation; // byte array
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
                Exception exception = ExceptionFactory("AssociateIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Associate to an user an already existing identity Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>Task of InlineResponse2004</returns>
        public async System.Threading.Tasks.Task<InlineResponse2004> AssociateIdentityAsync (string organizationId, Id userId, IdentityAssociation identityAssociation)
        {
             ApiResponse<InlineResponse2004> localVarResponse = await AssociateIdentityAsyncWithHttpInfo(organizationId, userId, identityAssociation);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Associate to an user an already existing identity Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> AssociateIdentityAsyncWithHttpInfo (string organizationId, Id userId, IdentityAssociation identityAssociation)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->AssociateIdentity");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->AssociateIdentity");
            // verify the required parameter 'identityAssociation' is set
            if (identityAssociation == null)
                throw new ApiException(400, "Missing required parameter 'identityAssociation' when calling IdentitiesApi->AssociateIdentity");

            var localVarPath = "/{organization-id}/users/{user-id}/wallet";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            if (identityAssociation != null && identityAssociation.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(identityAssociation); // http body (model) parameter
            }
            else
            {
                localVarPostBody = identityAssociation; // byte array
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
                Exception exception = ExceptionFactory("AssociateIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Create an identity from token This API allows to create an identity from a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>InlineResponse2012</returns>
        public InlineResponse2012 CreateTokenFromIdentity (string organizationId, CreateIdentitybyToken createIdentitybyToken)
        {
             ApiResponse<InlineResponse2012> localVarResponse = CreateTokenFromIdentityWithHttpInfo(organizationId, createIdentitybyToken);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create an identity from token This API allows to create an identity from a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        public ApiResponse<InlineResponse2012> CreateTokenFromIdentityWithHttpInfo (string organizationId, CreateIdentitybyToken createIdentitybyToken)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->CreateTokenFromIdentity");
            // verify the required parameter 'createIdentitybyToken' is set
            if (createIdentitybyToken == null)
                throw new ApiException(400, "Missing required parameter 'createIdentitybyToken' when calling IdentitiesApi->CreateTokenFromIdentity");

            var localVarPath = "/{organization-id}/identities/create/token";
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
            if (createIdentitybyToken != null && createIdentitybyToken.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createIdentitybyToken); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createIdentitybyToken; // byte array
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
                Exception exception = ExceptionFactory("CreateTokenFromIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Create an identity from token This API allows to create an identity from a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>Task of InlineResponse2012</returns>
        public async System.Threading.Tasks.Task<InlineResponse2012> CreateTokenFromIdentityAsync (string organizationId, CreateIdentitybyToken createIdentitybyToken)
        {
             ApiResponse<InlineResponse2012> localVarResponse = await CreateTokenFromIdentityAsyncWithHttpInfo(organizationId, createIdentitybyToken);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create an identity from token This API allows to create an identity from a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> CreateTokenFromIdentityAsyncWithHttpInfo (string organizationId, CreateIdentitybyToken createIdentitybyToken)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->CreateTokenFromIdentity");
            // verify the required parameter 'createIdentitybyToken' is set
            if (createIdentitybyToken == null)
                throw new ApiException(400, "Missing required parameter 'createIdentitybyToken' when calling IdentitiesApi->CreateTokenFromIdentity");

            var localVarPath = "/{organization-id}/identities/create/token";
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
            if (createIdentitybyToken != null && createIdentitybyToken.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createIdentitybyToken); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createIdentitybyToken; // byte array
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
                Exception exception = ExceptionFactory("CreateTokenFromIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Delete the appearance of an identity This API allows to delete the appearance associated to an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2004</returns>
        public InlineResponse2004 DeleteAppearance (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2004> localVarResponse = DeleteAppearanceWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete the appearance of an identity This API allows to delete the appearance associated to an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        public ApiResponse<InlineResponse2004> DeleteAppearanceWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteAppearance");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->DeleteAppearance");

            var localVarPath = "/{organization-id}/identities/{identity-id}/appearance";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteAppearance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Delete the appearance of an identity This API allows to delete the appearance associated to an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2004</returns>
        public async System.Threading.Tasks.Task<InlineResponse2004> DeleteAppearanceAsync (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2004> localVarResponse = await DeleteAppearanceAsyncWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete the appearance of an identity This API allows to delete the appearance associated to an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> DeleteAppearanceAsyncWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteAppearance");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->DeleteAppearance");

            var localVarPath = "/{organization-id}/identities/{identity-id}/appearance";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteAppearance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Delete an enrollment request This API allows to delete an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>InlineResponse2012</returns>
        public InlineResponse2012 DeleteEnrollmentRequest (string organizationId, Id enrollmentId)
        {
             ApiResponse<InlineResponse2012> localVarResponse = DeleteEnrollmentRequestWithHttpInfo(organizationId, enrollmentId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete an enrollment request This API allows to delete an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        public ApiResponse<InlineResponse2012> DeleteEnrollmentRequestWithHttpInfo (string organizationId, Id enrollmentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteEnrollmentRequest");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->DeleteEnrollmentRequest");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteEnrollmentRequest", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Delete an enrollment request This API allows to delete an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of InlineResponse2012</returns>
        public async System.Threading.Tasks.Task<InlineResponse2012> DeleteEnrollmentRequestAsync (string organizationId, Id enrollmentId)
        {
             ApiResponse<InlineResponse2012> localVarResponse = await DeleteEnrollmentRequestAsyncWithHttpInfo(organizationId, enrollmentId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete an enrollment request This API allows to delete an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> DeleteEnrollmentRequestAsyncWithHttpInfo (string organizationId, Id enrollmentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteEnrollmentRequest");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->DeleteEnrollmentRequest");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteEnrollmentRequest", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Delete an identity This API allows to delete an identity of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2003</returns>
        public InlineResponse2003 DeleteIdentity (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2003> localVarResponse = DeleteIdentityWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete an identity This API allows to delete an identity of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2003</returns>
        public ApiResponse<InlineResponse2003> DeleteIdentityWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteIdentity");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->DeleteIdentity");

            var localVarPath = "/{organization-id}/identities/{identity-id}";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2003>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2003) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2003)));
        }

        /// <summary>
        /// Delete an identity This API allows to delete an identity of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2003</returns>
        public async System.Threading.Tasks.Task<InlineResponse2003> DeleteIdentityAsync (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2003> localVarResponse = await DeleteIdentityAsyncWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete an identity This API allows to delete an identity of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2003)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2003>> DeleteIdentityAsyncWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteIdentity");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->DeleteIdentity");

            var localVarPath = "/{organization-id}/identities/{identity-id}";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2003>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2003) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2003)));
        }

        /// <summary>
        /// Get information about an enrollment request This API allows to get information about an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>InlineResponse2011</returns>
        public InlineResponse2011 GetEnrollmentRequest (string organizationId, Id enrollmentId)
        {
             ApiResponse<InlineResponse2011> localVarResponse = GetEnrollmentRequestWithHttpInfo(organizationId, enrollmentId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about an enrollment request This API allows to get information about an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        public ApiResponse<InlineResponse2011> GetEnrollmentRequestWithHttpInfo (string organizationId, Id enrollmentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->GetEnrollmentRequest");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->GetEnrollmentRequest");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter

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
                Exception exception = ExceptionFactory("GetEnrollmentRequest", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Get information about an enrollment request This API allows to get information about an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of InlineResponse2011</returns>
        public async System.Threading.Tasks.Task<InlineResponse2011> GetEnrollmentRequestAsync (string organizationId, Id enrollmentId)
        {
             ApiResponse<InlineResponse2011> localVarResponse = await GetEnrollmentRequestAsyncWithHttpInfo(organizationId, enrollmentId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get information about an enrollment request This API allows to get information about an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> GetEnrollmentRequestAsyncWithHttpInfo (string organizationId, Id enrollmentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->GetEnrollmentRequest");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->GetEnrollmentRequest");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter

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
                Exception exception = ExceptionFactory("GetEnrollmentRequest", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Get information about an identity This API allows to get all the information of an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2002</returns>
        public InlineResponse2002 GetIdentity (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2002> localVarResponse = GetIdentityWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about an identity This API allows to get all the information of an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        public ApiResponse<InlineResponse2002> GetIdentityWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->GetIdentity");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->GetIdentity");

            var localVarPath = "/{organization-id}/identities/{identity-id}";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("GetIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// Get information about an identity This API allows to get all the information of an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2002</returns>
        public async System.Threading.Tasks.Task<InlineResponse2002> GetIdentityAsync (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2002> localVarResponse = await GetIdentityAsyncWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get information about an identity This API allows to get all the information of an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> GetIdentityAsyncWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->GetIdentity");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->GetIdentity");

            var localVarPath = "/{organization-id}/identities/{identity-id}";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("GetIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// Enumerate the enrollment requests of an organization This API allows to enumerate the enrollment requests of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2005</returns>
        public InlineResponse2005 ListEnrollmentRequests (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2005> localVarResponse = ListEnrollmentRequestsWithHttpInfo(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Enumerate the enrollment requests of an organization This API allows to enumerate the enrollment requests of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2005</returns>
        public ApiResponse<InlineResponse2005> ListEnrollmentRequestsWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListEnrollmentRequests");

            var localVarPath = "/{organization-id}/identity-requests";
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
            if (whereProvider != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_provider", whereProvider)); // query parameter
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereFirstName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_first_name", whereFirstName)); // query parameter
            if (whereLastName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_last_name", whereLastName)); // query parameter
            if (whereRegisteredBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_registered_by", whereRegisteredBy)); // query parameter
            if (whereFiscalCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_fiscal_code", whereFiscalCode)); // query parameter
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
                Exception exception = ExceptionFactory("ListEnrollmentRequests", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2005>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2005) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2005)));
        }

        /// <summary>
        /// Enumerate the enrollment requests of an organization This API allows to enumerate the enrollment requests of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2005</returns>
        public async System.Threading.Tasks.Task<InlineResponse2005> ListEnrollmentRequestsAsync (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2005> localVarResponse = await ListEnrollmentRequestsAsyncWithHttpInfo(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Enumerate the enrollment requests of an organization This API allows to enumerate the enrollment requests of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2005)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2005>> ListEnrollmentRequestsAsyncWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListEnrollmentRequests");

            var localVarPath = "/{organization-id}/identity-requests";
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
            if (whereProvider != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_provider", whereProvider)); // query parameter
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereFirstName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_first_name", whereFirstName)); // query parameter
            if (whereLastName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_last_name", whereLastName)); // query parameter
            if (whereRegisteredBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_registered_by", whereRegisteredBy)); // query parameter
            if (whereFiscalCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_fiscal_code", whereFiscalCode)); // query parameter
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
                Exception exception = ExceptionFactory("ListEnrollmentRequests", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2005>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2005) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2005)));
        }

        /// <summary>
        /// Enumerate the identities of an organization This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2001</returns>
        public InlineResponse2001 ListIdentities (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2001> localVarResponse = ListIdentitiesWithHttpInfo(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Enumerate the identities of an organization This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2001</returns>
        public ApiResponse<InlineResponse2001> ListIdentitiesWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListIdentities");

            var localVarPath = "/{organization-id}/identities";
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
            if (whereProvider != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_provider", whereProvider)); // query parameter
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereFirstName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_first_name", whereFirstName)); // query parameter
            if (whereLastName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_last_name", whereLastName)); // query parameter
            if (whereRegisteredBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_registered_by", whereRegisteredBy)); // query parameter
            if (whereFiscalCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_fiscal_code", whereFiscalCode)); // query parameter
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
                Exception exception = ExceptionFactory("ListIdentities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2001>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2001) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2001)));
        }

        /// <summary>
        /// Enumerate the identities of an organization This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2001</returns>
        public async System.Threading.Tasks.Task<InlineResponse2001> ListIdentitiesAsync (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2001> localVarResponse = await ListIdentitiesAsyncWithHttpInfo(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Enumerate the identities of an organization This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2001)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2001>> ListIdentitiesAsyncWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListIdentities");

            var localVarPath = "/{organization-id}/identities";
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
            if (whereProvider != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_provider", whereProvider)); // query parameter
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereFirstName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_first_name", whereFirstName)); // query parameter
            if (whereLastName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_last_name", whereLastName)); // query parameter
            if (whereRegisteredBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_registered_by", whereRegisteredBy)); // query parameter
            if (whereFiscalCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_fiscal_code", whereFiscalCode)); // query parameter
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
                Exception exception = ExceptionFactory("ListIdentities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2001>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2001) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2001)));
        }

        /// <summary>
        /// List the enrollments of an user This API allows to list all the enrollments of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2005</returns>
        public InlineResponse2005 ListUserEnrollments (string organizationId, Id userId, int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2005> localVarResponse = ListUserEnrollmentsWithHttpInfo(organizationId, userId, page, count);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List the enrollments of an user This API allows to list all the enrollments of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2005</returns>
        public ApiResponse<InlineResponse2005> ListUserEnrollmentsWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListUserEnrollments");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->ListUserEnrollments");

            var localVarPath = "/{organization-id}/users/{user-id}/identity-requests";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
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
                Exception exception = ExceptionFactory("ListUserEnrollments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2005>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2005) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2005)));
        }

        /// <summary>
        /// List the enrollments of an user This API allows to list all the enrollments of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2005</returns>
        public async System.Threading.Tasks.Task<InlineResponse2005> ListUserEnrollmentsAsync (string organizationId, Id userId, int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2005> localVarResponse = await ListUserEnrollmentsAsyncWithHttpInfo(organizationId, userId, page, count);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List the enrollments of an user This API allows to list all the enrollments of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2005)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2005>> ListUserEnrollmentsAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListUserEnrollments");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->ListUserEnrollments");

            var localVarPath = "/{organization-id}/users/{user-id}/identity-requests";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
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
                Exception exception = ExceptionFactory("ListUserEnrollments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2005>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2005) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2005)));
        }

        /// <summary>
        /// Enumerate the identities of an user This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>InlineResponse2001</returns>
        public InlineResponse2001 ListUserIdentities (string organizationId, Id userId, int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2001> localVarResponse = ListUserIdentitiesWithHttpInfo(organizationId, userId, page, count);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Enumerate the identities of an user This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>ApiResponse of InlineResponse2001</returns>
        public ApiResponse<InlineResponse2001> ListUserIdentitiesWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListUserIdentities");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->ListUserIdentities");

            var localVarPath = "/{organization-id}/users/{user-id}/wallet";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
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
                Exception exception = ExceptionFactory("ListUserIdentities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2001>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2001) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2001)));
        }

        /// <summary>
        /// Enumerate the identities of an user This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of InlineResponse2001</returns>
        public async System.Threading.Tasks.Task<InlineResponse2001> ListUserIdentitiesAsync (string organizationId, Id userId, int page = default(int), int count = default(int))
        {
             ApiResponse<InlineResponse2001> localVarResponse = await ListUserIdentitiesAsyncWithHttpInfo(organizationId, userId, page, count);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Enumerate the identities of an user This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (InlineResponse2001)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2001>> ListUserIdentitiesAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListUserIdentities");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->ListUserIdentities");

            var localVarPath = "/{organization-id}/users/{user-id}/wallet";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
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
                Exception exception = ExceptionFactory("ListUserIdentities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2001>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2001) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2001)));
        }

        /// <summary>
        /// Submit an enrollment request This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>InlineResponse2011</returns>
        public InlineResponse2011 RequestEnrollment (string organizationId, IdentityRequest identityRequest)
        {
             ApiResponse<InlineResponse2011> localVarResponse = RequestEnrollmentWithHttpInfo(organizationId, identityRequest);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Submit an enrollment request This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        public ApiResponse<InlineResponse2011> RequestEnrollmentWithHttpInfo (string organizationId, IdentityRequest identityRequest)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->RequestEnrollment");
            // verify the required parameter 'identityRequest' is set
            if (identityRequest == null)
                throw new ApiException(400, "Missing required parameter 'identityRequest' when calling IdentitiesApi->RequestEnrollment");

            var localVarPath = "/{organization-id}/enroll";
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
            if (identityRequest != null && identityRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(identityRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = identityRequest; // byte array
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
                Exception exception = ExceptionFactory("RequestEnrollment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Submit an enrollment request This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>Task of InlineResponse2011</returns>
        public async System.Threading.Tasks.Task<InlineResponse2011> RequestEnrollmentAsync (string organizationId, IdentityRequest identityRequest)
        {
             ApiResponse<InlineResponse2011> localVarResponse = await RequestEnrollmentAsyncWithHttpInfo(organizationId, identityRequest);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Submit an enrollment request This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> RequestEnrollmentAsyncWithHttpInfo (string organizationId, IdentityRequest identityRequest)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->RequestEnrollment");
            // verify the required parameter 'identityRequest' is set
            if (identityRequest == null)
                throw new ApiException(400, "Missing required parameter 'identityRequest' when calling IdentitiesApi->RequestEnrollment");

            var localVarPath = "/{organization-id}/enroll";
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
            if (identityRequest != null && identityRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(identityRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = identityRequest; // byte array
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
                Exception exception = ExceptionFactory("RequestEnrollment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

    }
}
