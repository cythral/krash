#!/bin/bash

image=$1
cwd=$(dirname "${BASH_SOURCE[0]}")

for file in $(ls ${cwd}/params/*.json); do
    envName=$(echo $file | xargs basename | sed "s/\.json//")
    params=$(cat $file)
    params=$(echo $params | jq ".Image=\"$image\"")
    
    config={}
    config=$(echo $config | jq --argjson params "$params" '.Parameters=$params')
    echo $config > krash.${envName}.config.json
done