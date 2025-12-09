#!/usr/bin/env python3

import argparse
import subprocess

def nmap_scan(target):
    print(f"Scanning {target} with Nmap...")
    subprocess.call(["nmap", "-sV", target])

def whois_lookup(target):
    print(f"Performing Whois lookup on {target}...")
    subprocess.call(["whois", target])

def main():
    parser = argparse.ArgumentParser(description="OSINT Toolkit")
    parser.add_argument("tool", choices=["nmap", "whois"], help="Choose a tool to use")
    parser.add_argument("target", help="Target to analyze")

    args = parser.parse_args()

    if args.tool == "nmap":
        nmap_scan(args.target)
    elif args.tool == "whois":
        whois_lookup(args.target)

if __name__ == "__main__":
    main()