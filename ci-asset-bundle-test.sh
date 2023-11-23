#!/usr/bin/env bash
# THIS FILE IS INTENDED TO BE USED IN THE CI ONLY

set -u  # fail if any env var is not set

source ci-setup.sh

SCENE_ID="$(curl -s "https://testnet-peer.memetaverse.club/content/entities/scene?pointer=-110,-110" | jq -r '.[0].id')"
echo "Testing scene at -110,-110: $SCENE_ID"

pwd

# Parameters are passed as ENV vars
export SCENE_ID
export OUTPUT_DIR=ab-output
export LOCAL_LOG_FILE="$(pwd)/ab-logs.txt"
export CONTENT_URL="https://testnet-peer.memetaverse.club/lambdas/contentv2/contents/"

# call the conversor
bash ./convert-asset-bundles.sh
