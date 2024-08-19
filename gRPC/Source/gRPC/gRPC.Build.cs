// Copyright Epic Games, Inc. All Rights Reserved.

using System;
using System.IO;
using UnrealBuildTool;
using EpicGames.Core;

public class gRPC : ModuleRules
{
	public gRPC(ReadOnlyTargetRules Target) : base(Target)
	{
        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine",
            "OpenSSL",
            "zlib",
            "InputCore",  // 필요한 다른 모듈 추가
            "EnhancedInput"
        });

        string thirdPartyPath = Path.Combine(ModuleDirectory, "..", "..", "ThirdParty", "grpc");

        PublicIncludePaths.Add(Path.Combine(thirdPartyPath, "protobuf", "src"));

        // gRPC와 관련된 define 설정 추가
        PublicDefinitions.Add("GOOGLE_PROTOBUF_INTERNAL_DONATE_STEAL_INLINE=0");
        PublicDefinitions.Add("GPR_FORBID_UNREACHABLE_CODE=0");
        PublicDefinitions.Add("GRPC_USE_PROTO_LITE=0");
    }

}
