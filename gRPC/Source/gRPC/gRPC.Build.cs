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
            "InputCore",  // �ʿ��� �ٸ� ��� �߰�
            "EnhancedInput"
        });

        string thirdPartyPath = Path.Combine(ModuleDirectory, "..", "..", "ThirdParty", "grpc");

        PublicIncludePaths.Add(Path.Combine(thirdPartyPath, "protobuf", "src"));

        // gRPC�� ���õ� define ���� �߰�
        PublicDefinitions.Add("GOOGLE_PROTOBUF_INTERNAL_DONATE_STEAL_INLINE=0");
        PublicDefinitions.Add("GPR_FORBID_UNREACHABLE_CODE=0");
        PublicDefinitions.Add("GRPC_USE_PROTO_LITE=0");
    }

}
