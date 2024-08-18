// Copyright Epic Games, Inc. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class gRPC : ModuleRules
{
	public gRPC(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "EnhancedInput" });

		// gRPC ��� ����
		string grpcPath = Path.Combine(ModuleDirectory, "ThirdParty", "grpc");

		// gRPC ���̺귯��, ��� ���� ���
		PublicIncludePaths.Add(Path.Combine(grpcPath, "include"));
		PublicAdditionalLibraries.Add(Path.Combine(grpcPath, "lib","grpc.lib"));

        // �÷��� ����
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            string openSSLPath = Path.Combine(ModuleDirectory, "ThirdParty", "OpenSSL", "Win64");
            PublicIncludePaths.Add(Path.Combine(openSSLPath, "include"));
            PublicAdditionalLibraries.Add(Path.Combine(openSSLPath, "lib", "libssl.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(openSSLPath, "lib", "libcrypto.lib"));
        }

        // 
        PublicDefinitions.Add("GRPC_USE_PROTO_LITE=0");
    }
}
